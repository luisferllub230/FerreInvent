using StockApp.Core.Domain.Entities;
using StockApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Interfaces.Repositories.IProduct
{
    public interface IProductRepository
    {
        public Task addRepository(Product product);
        public Task updateRepository(Product product);
        public Task deleteRepository(Product product);
        public Task<List<Product>> getAllRepository();
        public Task<Product> getByIdRepository(int id);
    }
}
