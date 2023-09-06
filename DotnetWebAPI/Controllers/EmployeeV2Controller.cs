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
    public class EmployeeV2Controller : ApiController
    {
        List<EmployeeV2> lstEmp = new List<EmployeeV2>()
{
new EmployeeV2{ID=1,Name="Anoop Sharma",Age=26,City="Delhi",State="Delhi",DOB=new DateTime()},
new EmployeeV2{ID=2,Name="Ramesh Sharma",Age=30,City="Amritsar",State="Punjab",DOB=new DateTime()},
};

        //Public IEnumerable<EmployeeV2> Get()
        //{
        //    return lstEmp;
        //}

        //Public EmployeeV2 Get(int ID)
        //{
        //    return lstEmp.FirstOrDefault(x => x.ID == ID);

        //}
      //  [Route("api/v2/Employee")]
        public IHttpActionResult Get()
        {
            return Ok(lstEmp);
        }

      //  [Route("api/v2/Employee/{id}")]
        public IHttpActionResult Get(int ID)
        {
            return Ok(lstEmp.FirstOrDefault(x => x.ID == ID));
        }
    }
}
