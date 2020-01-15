using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileForensiq.Database
{
    public class DatabaseConfig
    {

        /// <summary>
        /// Returning connection string for db from app.config file.
        /// </summary>
        /// <param name="name">Name of database used in app.config file.</param>
        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

    }
}
