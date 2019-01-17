using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Stock_Archives_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StockController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Stock/{companyName}")]
        public IHttpActionResult Get(string companyName)
        {
            try
            {
                StockService service = new StockService(new StockRepository());
                if (!string.IsNullOrWhiteSpace(companyName))
                {
                    var result = service.GetStocks(companyName);
                    return Ok(result);
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Stock/{companyName}/{year}")]
        public IHttpActionResult Get(string companyName, string year)
        {
            try
            {
                int selectedYear = System.Convert.ToInt32(year);
                StockService service = new StockService(new StockRepository());
                if (!string.IsNullOrWhiteSpace(companyName) && selectedYear > 0)
                {
                    var result = service.GetStocks(companyName, selectedYear);
                    return Ok(result);
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Stock/{companyName}/{fromDate}/{toDate}")]
        public IHttpActionResult Get(string companyName, string fromDate, string toDate)
        {
            try
            {
                StockService service = new StockService(new StockRepository());
                if (!string.IsNullOrWhiteSpace(companyName))
                {
                    var result = service.GetStocks(companyName,fromDate,toDate);
                    return Ok(result);
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [ActionName("GetBestPerformingCompany")]
        [Route("api/Stock/GetBestPerformingCompany/{year}")]
        public IHttpActionResult GetBestPerformingCompany(string year)
        {
            try
            {
                StockService service = new StockService(new StockRepository());
                var result = service.GetBestStockByYear(year);
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [ActionName("GetYearsRange")]
        [Route("api/Stock/GetYearsRange/")]
        public IHttpActionResult GetYearsRange()
        {
            try
            {
                StockService service = new StockService(new StockRepository());
                var result = service.GetYears();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
