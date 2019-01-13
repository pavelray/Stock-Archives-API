using Models;
using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace Stock_Archives_API.Controllers
{
    public class DumpDataController : ApiController
    {
        [HttpGet]
        //[Route("api/DumpData/{filePath}")]
        public IHttpActionResult Get()
        {
            string filePath = string.Empty;
            string path = string.Empty;

            if (!string.IsNullOrWhiteSpace(path))
            {
                filePath = path;
            }
            else
            {
                //filePath = "C:\\Users\\Pavel\\Desktop\\prices763fefc.csv";
                filePath = HttpContext.Current.Server.MapPath("~/App_Data/prices763fefc.csv");
            }

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
