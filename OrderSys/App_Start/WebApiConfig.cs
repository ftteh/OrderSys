using System.Web.Http;

namespace OrderSys
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{oc}",
                defaults: new { oc = RouteParameter.Optional }
            );


        }
    }
}
