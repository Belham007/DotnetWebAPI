using DotnetWebAPI.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotnetWebAPI.Controllers
{
    public class EmployeeV1Controller : ApiController
    {
        List<EmployeeV1> lstEmp = new List<EmployeeV1>()
{
new EmployeeV1{ID=1,Name="Anoop Sharma",Age=26,City="Delhi",State="Delhi"},
new EmployeeV1{ID=2,Name="Ramesh Sharma",Age=30,City="Amritsar",State="Punjab"},
};

        //Public IEnumerable<EmployeeV1> Get()
        //{
        //    return lstEmp;
        //}


        //Public EmployeeV1 Get(int ID)
        //{
        //    return lstEmp.FirstOrDefault(x => x.ID == ID);

        //}
       // [Route("api/v1/Employee")]
        public IHttpActionResult Get()
        {
            return Ok(lstEmp);
        }
      //  [Route("api/v1/Employee/{id}")]
        public IHttpActionResult Get(int ID)
        {
            return Ok(lstEmp.FirstOrDefault(x => x.ID == ID));
        }
    }
}
