using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IStockService
    {
        IEnumerable<Stock> GetStocks(string companyName);

        IEnumerable<Stock> GetStocks(string companyName, int year);

        IEnumerable<Stock> GetStocks(string companyName, string fromDate, string toDate);

        IEnumerable<Stock> GetStockByYear(string year);

        IEnumerable<Stock> GetBestStockByYear(string year);

        IEnumerable<int> GetYears();


    }

}
