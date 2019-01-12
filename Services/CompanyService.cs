using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Models;
using Repository;

namespace Services
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _repository;
        private readonly ILog _logger = LogManager.GetLogger("StockService");

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            try
            {
                var result = _repository.GetAllCompanies();
                _logger.Info("GetAllCompanies : Success");

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error("Exception on GetAllCompanies" + ex.Message.ToString(), ex);
                throw ex;
            }
        }
    }
}
