using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetStocks(string companyName);
        IEnumerable<Stock> GetStocks(string companyName, string fromDate, string toDate);
    }
}
