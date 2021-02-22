using EmployeeServiceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace EmployeeServiceWebAPI.Controllers
{
    public class StudentV2Controller : ApiController
    {
       public  List<StudentV2> students = new List<StudentV2>()
        {
            new StudentV2{Id=1,FirstName="Avnish",LastName="Choubey"},
            new StudentV2{Id=2,FirstName="Manish",LastName="Choubey"},
            new StudentV2{Id=3,FirstName="Savita",LastName="Khanna"}
         };

        [Route("api/v2/students")]
        public IHttpActionResult Get()
        {
            return Ok(students.ToList());
        }
        [Route("api/v2/students/{id}")]
        public IHttpActionResult GetStudent(int id)
        {
            var model  =students.FirstOrDefault(a => a.Id  == id);
            if(model == null)
            {
                return NotFound();
            }
            return Ok(model);
            
        }
    }
}
