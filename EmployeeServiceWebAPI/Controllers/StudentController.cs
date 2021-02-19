using EmployeeServiceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeServiceWebAPI.Controllers
{
   [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        public List<Student> students = new List<Student>()
        {
            new Student{id =101,Name="Avnish" , RollNo=1},
            new Student{id=102,Name="manish",RollNo =2},
            new Student {id=103,Name="Twinkle",RollNo =3}

        };
        [Route ("")]
        public IEnumerable<Student>  Get()
        {
            return students.ToList();
        }
        [Route("{id:int:max(102)}")]
         public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(a => a.id == id);
        }
        [Route("{name:alpha}")]
        public Student GetStudentByName(string  name)
        {
            return students.FirstOrDefault(a => a.Name.ToLower()  == name.ToLower());
        }
        [Route("{id}/course")]
        public IEnumerable<string> GetCourseName (int id)
        {
            if(id==101)
            {
                return new  List<string>(){ "C#","ASP.NET","WebAPI"};
            }
            else if(id==102)
            {
                return new List<string>() { "CASP.NET ", "WebAPI" };
            }
            else
            {
                return new List<string>() { "Bootstrip", "CSS", "Angular" };
            }
        }
        [Route("")]
        public HttpResponseMessage Post([FromBody ] Student student )
        {
            students.Add(student);
            var response = Request.CreateResponse(HttpStatusCode.Created, students);
            response.Headers.Location = new Uri(Request.RequestUri + student.id.ToString());
            return response;

        }
       
    }
}
