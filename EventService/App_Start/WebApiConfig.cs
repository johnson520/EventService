using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EventService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //  enable global wildcard CORS
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            //  response with JSON to text/html requests
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }
}