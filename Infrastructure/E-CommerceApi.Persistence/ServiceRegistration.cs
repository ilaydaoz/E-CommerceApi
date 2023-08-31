using E_CommerceApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_CommerceApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EfContext>(x =>
            {
                x.UseNpgsql(configuration.GetConnectionString("EfDbContext"));
            });
            services.AddScoped<DbContext, EfContext>();
        }
    }
}
