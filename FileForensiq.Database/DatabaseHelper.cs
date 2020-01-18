using Dapper;
using FileForensiq.Core.Logger;
using FileForensiq.Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileForensiq.Database
{
    public class DatabaseHelper
    {
        private SqlCommand sqlCommand;
        private SqlTransaction sqlTransaction;
        private SqlBulkCopy sqlBulkCopy;

        /// <summary>
        /// Trying to open connection to SQL Server and if error doesn't occure then server is up and running.
        /// </summary>
        public bool CheckIfServerIsRunning()
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString("FileForensiqDB")))
            {
                try
                {
                    connection.Open();

                    return true;
                }
                catch (Exception ex)
                {
                    ErrorLogger.LogError("Server isn't running: " + ex.Message);
                    return false;
                }
                finally
                {
                    // Always close connection
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        /// <summary>
        /// Creates table for cache data and returns bool that indicates if table is created or not.
        /// </summary>
        public bool CreateTable(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString("FileForensiqDB")))
            {
                try
                {
                    connection.Open();

                    sqlTransaction = connection.BeginTransaction();

                    string query = "CREATE TABLE " + tableName +
                        " (Id int IDENTITY(1,1) PRIMARY KEY, Name varchar(max), " +
                        "Extension varchar(255), " +
                        "Size bigint, " +
                        "NumberOfFiles int, " +
                        "CreationTime datetime, " +
                        "LastAccessTime datetime, " +
                        "LastModificationTime datetime)";

                    sqlCommand = new SqlCommand(query, connection, sqlTransaction);

                    sqlCommand.ExecuteNonQuery();

                    sqlTransaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    ErrorLogger.LogError("Error while creating database table: " + ex.Message);
                    sqlTransaction.Rollback();

                    if (ex.Message.Contains("There is already an object named"))
                    {
                        return false;
                    }
                    throw ex;
                }
                finally
                {
                    // Always close connection
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        /// <summary>
        /// Bulk insertion of cache data.
        /// </summary>
        public void InsertCacheData(string tableName, DataTable data)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString("FileForensiqDB")))
            {
                try
                {
                    connection.Open();

                    sqlTransaction = connection.BeginTransaction();

                    sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, sqlTransaction);

                    sqlBulkCopy.DestinationTableName = tableName;

                    // Mapping columns from DataTable to table in db
                    sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                    sqlBulkCopy.ColumnMappings.Add("Extension", "Extension");
                    sqlBulkCopy.ColumnMappings.Add("Size", "Size");
                    sqlBulkCopy.ColumnMappings.Add("NumberOfFiles", "NumberOfFiles");
                    sqlBulkCopy.ColumnMappings.Add("CreationTime", "CreationTime");
                    sqlBulkCopy.ColumnMappings.Add("LastAccessTime", "LastAccessTime");
                    sqlBulkCopy.ColumnMappings.Add("LastModificationTime", "LastModificationTime");

                    sqlBulkCopy.WriteToServer(data);

                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    ErrorLogger.LogError("Error while inserting cache data to database: " + ex.Message);
                    sqlTransaction.Rollback();
                    throw ex;
                }
                finally
                {
                    // Always close connection
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        /// <summary>
        /// Returns DataTable object with right columns for cache data.
        /// </summary>
        public DataTable GenerateDataTableForBulkInsert()
        {
            DataTable tbl = new DataTable();

            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("Extension", typeof(string));
            tbl.Columns.Add("Size", typeof(long));
            tbl.Columns.Add("NumberOfFiles", typeof(int));
            tbl.Columns.Add("CreationTime", typeof(DateTime));
            tbl.Columns.Add("LastAccessTime", typeof(DateTime));
            tbl.Columns.Add("LastModificationTime", typeof(DateTime));

            return tbl;
        }

        /// <summary>
        /// Returns all tables names that has letter in their name.
        /// </summary>
        /// <param name="letter">Letter is for first letter of table.</param>
        /// <param name="connection">Already oppened connection.</param>
        public List<string> GetAllTableNames(string letter, IDbConnection connection)
        {
            string query = "SELECT DISTINCT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME LIKE '%" + letter + "%'";

            return connection.Query<string>(query).ToList();
        }

        /// <summary>
        /// Returns all file types stored in extension column in all tables.
        /// </summary>
        public List<string> GetFileTypes(string tableLetter)
        {
            using (IDbConnection connection = new SqlConnection(DatabaseConfig.ConnectionString("FileForensiqDB")))
            {
                try
                {
                    connection.Open();

                    List<string> tableNames = GetAllTableNames(tableLetter, connection);

                    string query = "SELECT DISTINCT " + tableNames[0] + ".Extension FROM " + tableNames[0];

                    foreach (var table in tableNames.Skip(1).ToList())
                    {
                        query += " LEFT JOIN " + table + " ON " + tableNames[0] + ".Extension = " + table + ".Extension";
                    }

                    query += " ORDER BY " + tableNames[0] + ".Extension";

                    return connection.Query<string>(query).ToList();
                }
                catch (Exception ex)
                {
                    ErrorLogger.LogError("Error while retriving file types: " + ex.Message);
                    throw;
                }
                finally
                {
                    // Always close connection
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        /// <summary>
        /// Returns all informations about files for specific types.
        /// </summary>
        public List<CacheModel> GetAllFiles(string tableLetter, List<string> types)
        {
            using (IDbConnection connection = new SqlConnection(DatabaseConfig.ConnectionString("FileForensiqDB")))
            {
                try
                {
                    connection.Open();

                    List<CacheModel> result = new List<CacheModel>();

                    List<string> tableNames = GetAllTableNames(tableLetter, connection);

                    foreach (var table in tableNames)
                    {
                        string query = "SELECT * FROM " + table + " WHERE Extension IN @types;";

                        result.AddRange(connection.Query<CacheModel>(query, new { types }).ToList());
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    ErrorLogger.LogError("Error while retriving files: " + ex.Message);
                    throw;
                }
                finally
                {
                    // Always close connection
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        /// <summary>
        /// Returns all files created between specific date.
        /// </summary>
        public List<CacheModel> GetFilesByPeriodOfTime(string tableLetter, string columnName, List<string> types, DateTime from, DateTime? to = null)
        {
            using (IDbConnection connection = new SqlConnection(DatabaseConfig.ConnectionString("FileForensiqDB")))
            {
                try
                {
                    connection.Open();

                    List<CacheModel> result = new List<CacheModel>();
                    List<string> tableNames = new List<string>();

                    tableNames.AddRange(GetAllTableNames(tableLetter, connection));

                    foreach (var table in tableNames)
                    {
                        string query = "";
                        if(to == null)
                        {
                            query = String.Format("SELECT * FROM {0} WHERE Convert(date,{1}) BETWEEN '{2}' AND '{3}' AND Extension IN {4}", table, columnName, from.ToString("yyyy/MM/dd"), from.AddHours(24).ToString("yyyy/MM/dd"), "@types");
                            result.AddRange(connection.Query<CacheModel>(query, new { types }).ToList());
                        }
                        else
                        {
                            query = String.Format("SELECT * FROM {0} WHERE Convert(date,{1}) BETWEEN '{2}' AND '{3}' AND Extension IN {4}", table, columnName, from.ToString("yyyy/MM/dd"), to?.AddHours(24).ToString("yyyy/MM/dd"), "@types");
                            result.AddRange(connection.Query<CacheModel>(query, new { types }).ToList());
                        }  
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    ErrorLogger.LogError("Error while retriving files: " + ex.Message);
                    throw;
                }
                finally
                {
                    // Always close connection
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        /// <summary>
        /// Returns file information from all tables for specific column.
        /// </summary>
        public List<CacheModel> GetFileColumnHistory(string tableLetter, string fileName)
        {
            using (IDbConnection connection = new SqlConnection(DatabaseConfig.ConnectionString("FileForensiqDB")))
            {
                try
                {
                    connection.Open();

                    List<CacheModel> result = new List<CacheModel>();

                    List<string> tableNames = GetAllTableNames(tableLetter, connection);

                    foreach (var table in tableNames)
                    {
                        string query = "SELECT * FROM " + table + " WHERE Name = @fileName;";

                        var tempResult = connection.Query<CacheModel>(query, new { fileName }).ToList();

                        foreach (var item in tempResult)
                        {
                            item.DateCached = table;
                        }

                        result.AddRange(tempResult);
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    ErrorLogger.LogError("Error while retriving files: " + ex.Message);
                    throw;
                }
                finally
                {
                    // Always close connection
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
    }
}
