using EmployeeServiceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeServiceWebAPI.Controllers
{
    [RoutePrefix ("api/person")]
    public class PersonController : ApiController
    {
        public List<Person> obj = new List<Person>()
        {

            new Person{id=1,name="Avnish"},
            new Person{id=2,name="manish"},
           new Person{id=3,name="Savita"}


         };
        [Route("")]
        public IHttpActionResult  Get()
        {
            return Ok(obj);
        }
        [Route("{id:int}")]
        public IHttpActionResult GetPersonByID(int id)
        {
            var person = obj.FirstOrDefault(a => a.id == id);
            if(person==null)
            {
                return NotFound();
            }
            return Ok(person);
        }
        //[Route("{name:alpha}")]
        //public Person GetPersonByName(string name)
        //{
        //    var person = obj.FirstOrDefault(a => a.name.ToLower() == name.ToLower());
        //    if (person == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound());
        //    }
        //    return Ok(person);
        //}
        [Route("")]
        public IHttpActionResult Post([FromBody ]Person person )
        {
            obj.Add(person);
            return Content(HttpStatusCode.Created, obj);
        }


    }
}
