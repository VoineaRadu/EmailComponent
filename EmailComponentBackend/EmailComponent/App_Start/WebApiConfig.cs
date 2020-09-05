using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EmailComponent.Controllers;
using Newtonsoft.Json;

namespace EmailComponent
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            // Web API routes
            config.EnableCors();
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings();
            config.MapHttpAttributeRoutes();
        }
    }
}
