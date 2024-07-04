using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Extantions
{
    public static class DatabaseExtantion
    {
        public static void AddDatabaseModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Transient);
        }

        public static IQueryable<Pump> AllIncludedPupms(this ApplicationContext context) 
        {
            return context.Pumps.Include(e => e.Motor)
                                .Include(e => e.ImpellerMaterial)
                                .Include(e => e.BodyMaterial);
        }
    }
}
