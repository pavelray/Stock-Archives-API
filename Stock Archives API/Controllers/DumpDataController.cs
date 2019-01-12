using Models;
using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Stock_Archives_API.Controllers
{
    public class DumpDataController : ApiController
    {
        //[Route("api/DumpData/{filePath}")]
        public IHttpActionResult Get()
        {
            string filePath = "C:\\prices763fefc.csv";
            try
            {
                StockArchiveService service = new StockArchiveService(new StockArchiveRepository());
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    var result = service.InsertSockArchivesBulkDate(filePath);
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
