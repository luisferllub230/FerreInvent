using Microsoft.EntityFrameworkCore;
using StockApp.Core.Application.Interfaces.Repositories.IProduct;
using StockApp.Core.Domain.Entities;
using StockApp.Infraestructure.persistence.Context;

namespace Aplication.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AplicationsContext _Dbcontext;

        public ProductRepository(AplicationsContext context) 
        {
            _Dbcontext = context;
        }

        public async Task addRepository(Product product) 
        {
            await _Dbcontext.AddAsync(product);
            await _Dbcontext.SaveChangesAsync();
        }

        public async Task updateRepository(Product product) 
        {
            _Dbcontext.Entry(product).State = EntityState.Modified;
            await _Dbcontext.SaveChangesAsync();
        }

        public async Task deleteRepository(Product product)
        {
            _Dbcontext.Set<Product>().Remove(product);
            await _Dbcontext.SaveChangesAsync();
        }

        public async Task<List<Product>> getAllRepository()
        {
            return await _Dbcontext.Set<Product>().ToListAsync();
        }

        public async Task<Product> getByIdRepository(int id)
        {
            return await _Dbcontext.Set<Product>().FindAsync(id);
        }
    }
}
