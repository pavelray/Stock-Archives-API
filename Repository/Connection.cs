using System;
using System.Configuration;
using System.Data;
using log4net;
using MySql.Data.MySqlClient;

namespace Repository
{
    public class Connection
    {
        private readonly string _connectionString;
        private readonly ILog _logger = LogManager.GetLogger("Connection");

        public Connection()
        {
            //connection string for MySQL
            _connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        }


        protected IDbConnection GetMySQLConnection()
        {
            try
            {
                _logger.Info("Establishing Connection");
                return new MySqlConnection(_connectionString);
            }
            catch (Exception ex)
            {
                _logger.Error("Error on creating Connection" + ex.Message.ToString(), ex);
            }
            return null;
        }
    }
}
