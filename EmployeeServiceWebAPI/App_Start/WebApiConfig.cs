using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace EmployeeServiceWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

         /*   config.Routes.MapHttpRoute(
                name: "StudentV1Api",
                routeTemplate: "api/v1/students/{id}",
                defaults: new { id = RouteParameter.Optional,controller = "StudentV1" }
            );

            config.Routes.MapHttpRoute(
                name: "StudentV2Api",
                routeTemplate: "api/v2/students/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "StudentV2" }
            ); */
        }
    }
}
