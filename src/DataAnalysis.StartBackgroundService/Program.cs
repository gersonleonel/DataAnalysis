#region usings
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
#endregion usings

namespace DataAnalysis.StartBackgroundService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                })
                .ConfigureServices(services => services.AddServices());
    }
}
