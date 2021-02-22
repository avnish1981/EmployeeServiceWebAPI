using EmployeeServiceWebAPI.Models;

using System.Collections.Generic;
using System.Linq;

using System.Web.Http;


namespace EmployeeServiceWebAPI.Controllers
{
    public class StudentV1Controller : ApiController
    {
        List<StudentV1> students = new List<StudentV1>()
        {
            new StudentV1{Id=1,Name="Avnish"},
            new StudentV1{Id=2,Name="Manish"},
            new StudentV1{Id=3,Name="Savita"}
       };

       [Route("api/v1/students")]
        public IHttpActionResult Get()
        {
            return Ok(students.ToList());
        }
        [Route("api/v1/students/{id}")]
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
