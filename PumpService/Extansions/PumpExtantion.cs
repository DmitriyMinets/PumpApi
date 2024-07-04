using Microsoft.Extensions.DependencyInjection;
using PumpService.Interface;

namespace PumpService.Extansions
{
    public static class PumpExtantion
    {
        public static void AddPumpService(this IServiceCollection services) 
        {
            services.AddTransient<IPumpService, PumpService>();
        }
    }
}
