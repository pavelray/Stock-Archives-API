using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using log4net;
using Models;

namespace Repository
{
    public class StockRepository : Connection,IStockRepository
    {

        private readonly IDbConnection _connection = null;
        private readonly ILog _logger = LogManager.GetLogger("StockArchiveRepository");

        public StockRepository()
        {
            _connection = GetMySQLConnection();
        }

        public IEnumerable<Stock> GetStocks(string companyName)
        {
            using (IDbConnection db = _connection)
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@companyName", companyName);

                var result = db.Query<Stock>("GetStocks", queryParameters, commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public IEnumerable<Stock> GetStocks(string companyName, string fromDate, string toDate)
        {
            using (IDbConnection db = _connection)
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@companyName", companyName);
                queryParameters.Add("@fromDate", fromDate);
                queryParameters.Add("@toDate", toDate);

                var result = db.Query<Stock>("GetStocksByDate", queryParameters, commandType: CommandType.StoredProcedure);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
