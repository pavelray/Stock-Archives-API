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
    public class CompanyRepository : Connection, ICompanyRepository
    {
        private readonly IDbConnection _connection = null;
        private readonly ILog _logger = LogManager.GetLogger("StockArchiveRepository");

        public CompanyRepository()
        {
            _connection = GetMySQLConnection();
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            using (IDbConnection db = _connection)
            {
                var queryParameters = new DynamicParameters();
                String sql = "SELECT Distinct symbol as Symbol FROM stock_archives_db.stock_archives;";
                var result = db.Query<Company>(sql);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
