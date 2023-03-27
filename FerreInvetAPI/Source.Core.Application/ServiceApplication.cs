using Microsoft.Extensions.DependencyInjection;
using Source.Core.Application.Interfaces.Services;
using Source.Core.Application.Services;

namespace Source.Core.Application
{
    public static class ServiceApplication
    {

        public static void AddApplicationContext(this IServiceCollection services) 
        {



            #region services
            services.AddTransient<IInventoryServices, InventoryServices>();
            #endregion
        }
    }
}