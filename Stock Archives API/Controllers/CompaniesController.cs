using Models;
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
    public class CompaniesController : ApiController
    {
        
        public IHttpActionResult Get()
        {
            try
            {
                CompanyService service = new CompanyService(new CompanyRepository());
               
                var result = service.GetAllCompanies().ToList<Company>();

                result.RemoveAt(0);

                return Ok(result.OrderBy(x=> x.Symbol));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
