using Autofac;
using Hangfire;
using Hangfire.Logging;
using Hangfire.Logging.LogProviders;
using Hangfire.SqlServer;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Net.Http.Headers;

internal class JsonContentNegotiator : IContentNegotiator
{
    private readonly JsonMediaTypeFormatter _jsonFormatter;

    public JsonContentNegotiator(JsonMediaTypeFormatter formatter)
    {
        _jsonFormatter = formatter;
        _jsonFormatter.SerializerSettings.ContractResolver =
            new CamelCasePropertyNamesContractResolver();
    }

    public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
    {
        return new ContentNegotiationResult(_jsonFormatter, new MediaTypeHeaderValue("application/json"));
    }
}

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

            config.EnableCors();

            // Web API routes
            //config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Return json with lower case first letter of property names
            var jsonFormatter = new JsonMediaTypeFormatter();
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));


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
            //var path = @".\hangfir_queue";
            //MessageQueue m_Msq;
            //if (MessageQueue.Exists(path))
            //    m_Msq = new MessageQueue(path);
            //else
            //{
            //    m_Msq = MessageQueue.Create(path);
            //    m_Msq.MaximumQueueSize = 10000;
            //}
            //m_Msq.SetPermissions("Everyone", System.Messaging.MessageQueueAccessRights.FullControl);


            //var oldStorage = new SqlServerStorage(connectionString);
            //var oldOptions = new BackgroundJobServerOptions
            //{
            //    ServerName = "OldQueueServer" // Pass this to differentiate this server from the next one
            //};

            //appBuilder.UseHangfireServer(oldOptions, oldStorage);
            //GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString).UseMsmqQueues(@".\hangfire-{0}", "critical", "default");
            //https://discuss.hangfire.io/t/help-with-configuring-msmq/615/2
            GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString).UseMsmqQueues(@".\Private$\hangfire-{0}", "testqueue");

            appBuilder.UseHangfireDashboard();
            appBuilder.UseHangfireServer();

            //LogProvider.SetCurrentLogProvider(new ColouredConsoleLogProvider());
        }
    }
}
