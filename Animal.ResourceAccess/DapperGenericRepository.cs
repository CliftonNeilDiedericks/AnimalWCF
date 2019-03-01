using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;


namespace Animal.ResourceAccess
{
    public class DapperGenericRepository
    {
        

        private static string _connectionname;
        protected static IDbConnection connection;

        public DapperGenericRepository(string connectionName)
        {
            _connectionname = connectionName;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionname].ConnectionString);
        }
    }
}
