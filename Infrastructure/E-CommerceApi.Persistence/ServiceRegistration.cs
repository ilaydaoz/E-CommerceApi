using E_CommerceApi.Application.Repositories.Customers;
using E_CommerceApi.Application.Repositories.Orders;
using E_CommerceApi.Application.Repositories.Products;
using E_CommerceApi.Persistence.Contexts;
using E_CommerceApi.Persistence.Repositories.Customers;
using E_CommerceApi.Persistence.Repositories.Orders;
using E_CommerceApi.Persistence.Repositories.Products;
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
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
//AddScoped:tanımlanan bir hizmet, her HTTP isteği için bir kez oluşturulur ve
  //bu isteğin işlemi boyunca aynı hizmet örneği kullanılır.o isteği işlerken kullanılan hizmetler aynıdır ve bir sonraki istek geldiğinde
  //yeni bir hizmet örneği oluşturulur. 

//AddSingleton:uygulama yaşam döngüsü boyunca yalnızca bir kez oluşturulur ve tüm istemciler veya istekler tarafından paylaşılır.
  //Yani, her istemci veya istek, aynı hizmet örneğini kullanır.