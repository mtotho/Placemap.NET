using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace Tothdev.Placemap.API.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            JsonMediaTypeFormatter json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            json.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            json.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            config.Formatters.Clear();
            config.Formatters.Add(json);

            // Web API configuration and services
            config.EnableCors();
            //config.EnableCors(new AllowCorsAttribute());
            config.MapHttpAttributeRoutes();
            //config.Formatters.JsonFormatter.SerializerSettings.DateFormatString = "MM/dd/yyyy";


            // Web API routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Filters.Add(new ExceptionHandlingAttributeWebApi());
        }
    }
}