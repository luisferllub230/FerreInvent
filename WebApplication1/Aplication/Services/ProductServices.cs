using StockApp.Core.Application.Interfaces.Repositories.IProduct;
using StockApp.Core.Application.Interfaces.Services.IProduct;
using StockApp.Core.Application.ViewModel.Products;
using StockApp.Core.Domain.Entities;

namespace Aplication.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _repository;

        public ProductServices(IProductRepository productRepository) 
        {
            _repository = productRepository;
        }

        public async Task addServices(SaveProductViewModel vm ) 
        {
            var product = new Product();
            product.productName = vm.productName;
            product.productPrice = vm.productPrice;
            product.productDescription = vm.productDescription;
            product.productImg = vm.productImg;
            product.categoryId = vm.categoryId;

            await _repository.addRepository(product);
        }

        public async Task updateServices(SaveProductViewModel vm)
        {
            var product = new Product();
            product.id = vm.id; 
            product.productName = vm.productName;
            product.productPrice = vm.productPrice;
            product.productDescription = vm.productDescription;
            product.productImg = vm.productImg;
            product.categoryId = vm.categoryId;

            await _repository.updateRepository(product);
        }

        public async Task<SaveProductViewModel> getByIDservice(int id)
        {
            var products = await _repository.getByIdRepository(id);
            var productsVM = new SaveProductViewModel();

            productsVM.id = products.id;
            productsVM.productName = products.productName;
            productsVM.productPrice = products.productPrice;
            productsVM.productDescription = products.productDescription;
            productsVM.productImg = products.productImg;
            productsVM.categoryId = products.categoryId;

            return productsVM;
        }

        public async Task deleteService(int id)
        {
            var product = await _repository.getByIdRepository(id);
            await _repository.deleteRepository(product); 
        }

        public async Task<List<ProductViewModel>> getAllservice() 
        {
            var products = await _repository.getAllRepository();

            return products.Select(product => new ProductViewModel{
                productName = product.productName,
                productDescription = product.productDescription,
                productPrice = product.productPrice,
                productImg = product.productImg,
                id = product.id,
            }).ToList();
        }

    }
}
