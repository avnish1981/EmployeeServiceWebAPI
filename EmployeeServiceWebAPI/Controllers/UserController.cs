using EmpDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeServiceWebAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        //[Authorize]
        public HttpResponseMessage Users()
        {
            try
            {
                using (EmpDBConnection entities = new EmpDBConnection())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entities.Users.ToList());
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
