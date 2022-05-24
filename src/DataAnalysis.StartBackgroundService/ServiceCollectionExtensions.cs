#region usings
using DataAnalysis.Aplication.Services;
using DataAnalysis.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
#endregion usings

namespace DataAnalysis.StartBackgroundService
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IClientService), typeof(ClientService));
            services.AddSingleton(typeof(IIOService), typeof(IOService));
            services.AddSingleton(typeof(ISaleService), typeof(SaleService));
            services.AddSingleton(typeof(ISalesmanService), typeof(SalesmanService));
            services.AddSingleton(typeof(IWorkerService), typeof(WorkerService));
        }
    }
}
