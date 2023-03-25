using StockApp.Core.Application.ViewModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Interfaces.Services.IProduct
{
    public interface IProductServices
    {
        public Task addServices(SaveProductViewModel vm);
        public Task updateServices(SaveProductViewModel vm);
        public Task<SaveProductViewModel> getByIDservice(int id);
        public Task deleteService(int id);
        public Task<List<ProductViewModel>> getAllservice();
    }
}
