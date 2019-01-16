using log4net;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StockService: IStockService
    {
        private IStockRepository _repository;
        private readonly ILog _logger = LogManager.GetLogger("StockService");

        public StockService(IStockRepository repository)
        {
            _repository = repository;
        }


        public IEnumerable<Stock> GetStocks(string companyName)
        {
            try
            {
                var result = _repository.GetStocks(companyName);
                _logger.Info("GetStocks : Success");

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error("Exception on GetStocks" + ex.Message.ToString(), ex);
                throw ex;
            }
        }

        public IEnumerable<Stock> GetStocks(string companyName, string fromDate, string toDate)
        {
            try
            {
                var result = _repository.GetStocks(companyName, fromDate, toDate);
                _logger.Info("GetStocks by date range : Success");

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error("Exception on GetStocks by date range" + ex.Message.ToString(), ex);
                throw ex;
            }
        }

        public IEnumerable<Stock> GetBestStockByYear(string year = "2016")
        {
            try
            {
                IEnumerable<Stock> stocks = _repository.GetStockByYear(year);

                if (stocks != null)
                {
                    var stockPerformanceList = CalculateBestStocks(stocks);
                    _logger.Info("GetBestStockByYear : Success");

                    return stockPerformanceList;
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Exception on GetBestStockByYear" + ex.Message.ToString(), ex);
                throw ex;
            }

            return null;
        }

        public IEnumerable<Stock> GetStockByYear(string year)
        {
            try
            {
                var result = _repository.GetStockByYear(year);
                _logger.Info("GetStockByYear : Success");

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error("Exception on GetStockByYear" + ex.Message.ToString(), ex);
                throw ex;
            }
        }

        public static IEnumerable<Stock> CalculateBestStocks(IEnumerable<Stock> stocks)
        {
            var start_date = stocks.Select(x => x.Date).Min();
            var end_date = stocks.Select(x => x.Date).Max();

            var opening_stock = stocks.Where(s => s.Date == start_date).Select(x => new {x.Open,x.Symbol }).OrderBy(x=> x.Symbol);
            var closing_stock = stocks.Where(s => s.Date == end_date).Select(x => new { x.Close, x.Symbol }).OrderBy(x => x.Symbol);

            var profit_loss_list = opening_stock.Join(closing_stock, first => first.Symbol, second => second.Symbol ,(first, second) => 
                                    new Stock(){ Performance = (((second.Close-first.Open)/first.Open)*100), Symbol = first.Symbol }).OrderByDescending(x=> x.Performance).Take(20);

            return profit_loss_list;
        }
    }
}
