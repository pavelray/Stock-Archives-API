using Dapper;
using log4net;
using Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class StockArchiveRepository : Connection, IStockArchiveRepository
    {
        private readonly IDbConnection _connection = null;
        private readonly ILog _logger = LogManager.GetLogger("StockArchiveRepository");

        public StockArchiveRepository()
        {
            _connection = GetMySQLConnection();
        }

        public void GetStockArchivesData()
        {
            throw new NotImplementedException();
        }

        public bool InsertSockArchivesBulkDate(string filepath)
        {
            string file = @filepath;

            // MySQL BulkLoader
            MySqlBulkLoader bl = new MySqlBulkLoader((MySqlConnection)_connection);
            bl.TableName = "stock_archives";
            bl.FieldTerminator = ",";
            bl.LineTerminator = "\n";
            bl.FileName = file;

            try
            {
                _logger.Info("Connecting to MySQL...");
                _connection.Open();

                // Upload data from file
                int count = bl.Load();
                _logger.Info(count + " lines uploaded.");

                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool DeleteTopHeaderRow()
        {
            string sql = "DELETE FROM stock_archives_db.stock_archives limit 1;";
            using (IDbConnection db = _connection)
            {
                var result = db.Execute(sql);
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
