using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmpDataAccess.Model;

namespace EmployeeServiceWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Authorize]
        public HttpResponseMessage Employee()
        {
            try
            {
                using (EmpDBConnection entities = new EmpDBConnection())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.ToList());
                }

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message );
            }
            
        }
    }
}
