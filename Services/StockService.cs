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
    }
}
