using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Source.Core.Application.Interfaces.Repository;
using Source.Infraestructure.Persistence.Context;
using Source.Infraestructure.Persistence.Repositories;

namespace Source.Infraestructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastruture
            (this IServiceCollection services, IConfiguration configuration)
        {
            #region context 
            if (configuration.GetValue<bool>("UseInMemoryDataBase"))
            {
                services.AddDbContext<AplicationContext>(o => o.UseInMemoryDatabase("applicationDB"));
            }
            else
            {
                services.AddDbContext<AplicationContext>(
                    option => option.UseSqlServer(configuration.GetConnectionString("sqlConection"), 
                    m => m.MigrationsAssembly(typeof(AplicationContext).Assembly.FullName))
                );
            }

            #endregion

            #region repositories
            services.AddTransient(typeof(IGeneryRepository<>), typeof(GeneryRepository<>));
            services.AddTransient< ICategoryRepository, CategoriesRepository>();
            services.AddTransient< ICustumerRepository, CustumerRepository>();
            services.AddTransient< IInventoryRepository, InventoryRepository>();
            services.AddTransient< ISalesRepository, SalesRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            #endregion
        }
    }
}
