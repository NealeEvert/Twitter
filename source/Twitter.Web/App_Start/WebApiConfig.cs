using System.Web.Http;
using DryIoc;
using DryIoc.WebApi;
using Twitter.Common.Config;

namespace Twitter.Web
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
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = RouteParameter.Optional }
            );

            var container = new Container(rules => rules.With(FactoryMethod.ConstructorWithResolvableArguments));
            DryIocRegister.Configure(container);

            container.WithWebApi(config);
        }
    }
}
