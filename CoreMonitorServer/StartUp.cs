using Autofac;
using Hangfire;
using Hangfire.Logging;
using Hangfire.Logging.LogProviders;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoreMonitorServer
{
    public class Startup
    {
        // This code configures Web API.
        // The Startup class is specified as a type parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            // Web API routes
            //config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);

            //Error page handler
            //appBuilder.UseErrorPage();

            //appBuilder.Run(context =>
            //{
            //    // New code: Throw an exception for this URI path.
            //    if (context.Request.Path.Value == "/fail")
            //    {
            //        throw new Exception("Random exception");
            //    }

            //    context.Response.ContentType = "text/plain";
            //    return context.Response.WriteAsync("Hello, world.");
            //});


            //hangfire
            var containerBuilder = new ContainerBuilder();
            GlobalConfiguration.Configuration.UseAutofacActivator(containerBuilder.Build());

            string connectionString = "Data Source = .; Initial Catalog = EntityStore; Integrated Security=true; User ID = michael; Password = michael";

            GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString).UseMsmqQueues(@".\hangfire-{0}", "critical", "default");

            appBuilder.UseHangfireDashboard();
            appBuilder.UseHangfireServer();

            LogProvider.SetCurrentLogProvider(new ColouredConsoleLogProvider());
        }
    }
}
