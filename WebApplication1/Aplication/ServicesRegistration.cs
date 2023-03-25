using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Aplication.Services;
using StockApp.Core.Application.Interfaces.Services.IProduct;

namespace StockApp.Infraestructure.persistence
{
    public static class ServicesRegistration
    {
        public static void addAplicationLayer(this IServiceCollection service, IConfiguration configuration) 
        {

            #region repositories
            service.AddTransient<IProductServices, ProductServices>();
            #endregion
        }
    }
}
