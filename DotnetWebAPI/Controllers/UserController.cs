using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using DotnetWebAPI.Models;

namespace DotnetWebAPI.Controllers
{
    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/forall")]
        public IHttpActionResult Get()
        {
            // return Ok("Now server time is: " + DateTime.Now.ToString());
            List<Person> people = new List<Person>{
                   new Person{ID = 1, FirstName = "Scott", LastName = "Gurthie"},
                   new Person{ID = 2, FirstName = "Bill", LastName = "Gates"}
                   };
            return Ok(people);
        }

        [Authorize]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello " + identity.Name);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/data/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + " Role: " + string.Join(",", roles.ToList()));
        }
    }
}
