﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TariffsCalculator.App_Start;

namespace TariffsCalculator
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            StructuremapWebApi.Start();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
