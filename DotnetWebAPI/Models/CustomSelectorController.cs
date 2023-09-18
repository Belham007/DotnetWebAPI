using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http;

namespace DotnetWebAPI.Models
{
    public class CustomSelectorController : DefaultHttpControllerSelector
    {
        HttpConfiguration _config;
        public CustomSelectorController(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            //returns all possible API Controllers
            var controllers = GetControllerMapping();
            //return the information about the route
            var routeData = request.GetRouteData();
            //get the controller name passed
            var controllerName = routeData.Values["controller"].ToString();
            string apiVersion = "1";
            //get querystring from the URI
             /* var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);
              if (versionQueryString["version"] != null)
              {
                  apiVersion = Convert.ToString(versionQueryString["version"]);
              }*/
            //get Header
           /*  string customHeaderForVersion = "X-Employee-Version";
             if (request.Headers.Contains(customHeaderForVersion))
             {
                 apiVersion = request.Headers.GetValues(customHeaderForVersion).FirstOrDefault();
                 if (!string.IsNullOrEmpty(apiVersion) && apiVersion.Contains(','))
                 {
                     apiVersion = apiVersion.Split(',')[0];
                 }
             }*/
            //Get Accept Header which contains version
            //Check version Accept Header exists
            var acceptHeader = request.Headers.Accept.Where(b => b.Parameters.Count(t => t.Name.ToLower() == "version") > 0);
            if (acceptHeader.Any())
            {
                //Get the first value of version from the Accept Header Parameter
                apiVersion = acceptHeader.First().Parameters.First(x => x.Name.ToLower() == "version").Value;
            }
            
            if (apiVersion == "1")
            {
                controllerName = controllerName + "V1";
            }
            else
            {
                controllerName = controllerName + "V2";
            }
            //
            HttpControllerDescriptor controllerDescriptor;
            //check the value in controllers dictionary. TryGetValue is an efficient way to check the value existence
            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }
            return null;
        }
    }
}