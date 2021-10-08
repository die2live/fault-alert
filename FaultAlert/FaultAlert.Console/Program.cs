using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace FaultAlert.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.WriteLine("Fault Alert started!!!");

            var hostBuilder = new HostBuilder()
            .ConfigureAppConfiguration((hostContext, configBuilder) =>
            {
                configBuilder.SetBasePath(Directory.GetCurrentDirectory());
                configBuilder.AddJsonFile("appsettings.json", optional: true);
                configBuilder.AddJsonFile(
                    $"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
                    optional: true);
                configBuilder.AddEnvironmentVariables();
            })
            .ConfigureLogging((hostContext, configLogging) =>
            {
                configLogging.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                configLogging.AddConsole();
            })
            .ConfigureServices((hostContext, services) =>
            {
                // Here goes your internal application dependencies
                // like EntityFramework context, worker, endpoint, etc.
            });

            await hostBuilder.RunConsoleAsync();


            //while (true)
            //{
            //    ServiceProvider sp = new ACCServiceProvider();

            //    var alerts = sp.Update();

            //    var sender = new EmailSender();

            //    foreach (var alert in alerts)
            //    {
            //        sender.Send("alert", alert);
            //    }
            //    await Task.Delay(5000);
            //}


        }
    }
}
