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
    }
}
