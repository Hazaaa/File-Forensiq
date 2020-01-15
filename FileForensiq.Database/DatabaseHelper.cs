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
