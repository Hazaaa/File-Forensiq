using FileForensiq.Core.Logger;
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
                        " (Id int IDENTITY(1,1) PRIMARY KEY, Name text, " +
                        "Type varchar(255), " +
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

                    if(ex.Message.Contains("There is already an object named"))
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
                    sqlBulkCopy.ColumnMappings.Add("Type", "Type");
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
            tbl.Columns.Add("Type", typeof(string));
            tbl.Columns.Add("Size", typeof(long));
            tbl.Columns.Add("NumberOfFiles", typeof(int));
            tbl.Columns.Add("CreationTime", typeof(DateTime));
            tbl.Columns.Add("LastAccessTime", typeof(DateTime));
            tbl.Columns.Add("LastModificationTime", typeof(DateTime));

            return tbl;
        }
    }
}
