using Data;
using System.Configuration;
using System.Web;
using System.Web.Http;

namespace refactor_me
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Initialise Database
            string strConnect = ConfigurationManager.AppSettings["DBPath"].Replace("{DataDirectory}", HttpContext.Current.Server.MapPath("~/App_Data"));
            Database.Instance.Initialise(strConnect);

            // Web API configuration and services
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            formatters.JsonFormatter.Indent = true;

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
