using Hangfire;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CoreMonitorServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9001/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/Test").Result;
                var response2 = client.GetAsync(baseAddress + "api/Test/5").Result;


                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.WriteLine(response2);
                Console.WriteLine(response2.Content.ReadAsStringAsync().Result);

                RecurringJob.AddOrUpdate(
                () => Console.WriteLine("{0} Recurring job completed successfully!", DateTime.Now.ToString()),
                Cron.Minutely);

                BackgroundJob.Enqueue(() => Console.WriteLine($"{DateTime.Now.ToString()} once job executed successfully!"));
                BackgroundJob.Enqueue(() => test());

                Console.WriteLine("jixge__________________________________");

                Console.ReadLine();
            }
        }

        public static void test()
        {
            Thread.Sleep(10000);
            Console.WriteLine("job execution");
        }
    }
}
