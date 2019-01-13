using log4net;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StockArchiveService : IStockArchiveService
    {
        private IStockArchiveRepository _repository;
        private readonly ILog _logger = LogManager.GetLogger("StockArchiveService");

        public StockArchiveService(IStockArchiveRepository repository)
        {
            _repository = repository;
        }

        public bool InsertSockArchivesBulkDate(string filepath)
        {
            try
            {
                var result = _repository.InsertSockArchivesBulkDate(filepath);
                if (result)
                {
                    result = _repository.DeleteTopHeaderRow();
                    _logger.Info("Inserted Bulk Data : Success");
                    if (result)
                    {
                        _logger.Info("Deletion Column Row : Success");
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.Error("Exception on InsertSockArchivesBulkDate" + ex.Message.ToString(), ex);
                throw ex;
            }
        }
    }
}
