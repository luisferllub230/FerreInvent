using Source.Core.Application.DTO.Categories;
using Source.Core.Application.DTO.ErrorMessage;
using Source.Core.Application.DTO.Inventory;
using Source.Core.Application.Interfaces.Repository;
using Source.Core.Application.Interfaces.Services;
using Source.Core.Domain.Entities;


namespace Source.Core.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<(List<CategoryDTO>, ErrorMessageDTO)> getAllServices()
        {
            var error = new ErrorMessageDTO();
            var categories = await _categoryRepository.GetAllWhitIncluedeRepository(new List<string> { "inventories" });

            if (categories == null || categories.Count() == 0) 
            {
                error.IsError = true;
                error.ErrorMessage = "There arent category";
                return (null, error);
            }

            var categoryDTO = categories.Select(category => new CategoryDTO
            {
                id = category.id,
                categoryName = category.categoryName,
                inventories = category.inventories.Select(inventory => new InventoryDTO
                {
                    id = inventory.id,
                    inventoryName = inventory.inventoryName,
                    discount = inventory.discount,
                    bran = inventory.bran,
                    price = inventory.price,
                    quantity = inventory.quantity,
                }).ToList()
            }).ToList();

            return (categoryDTO, error);
        }

        public async Task<(CategoryDTO, ErrorMessageDTO)> getByIdServices(int id)
        {
            var error = new ErrorMessageDTO();
            var category = await _categoryRepository.GetByIdWhitIncludeRepository<Categories>(id, new List<string> { "inventories" });

            if (category == null)
            {
                error.IsError = true;
                error.ErrorMessage = "There arent category";
                return (null, error);
            }

            var categoryDTO = new CategoryDTO 
            {
                id = category.id,
                categoryName = category.categoryName,
                inventories = category.inventories.Select(inventory => new InventoryDTO
                {
                    id = inventory.id,
                    inventoryName = inventory.inventoryName,
                    discount = inventory.discount,
                    bran = inventory.bran,
                    price = inventory.price,
                    quantity = inventory.quantity,
                }).ToList()
            };


            return (categoryDTO, error);
        }

        public async Task postCreateServices(SaveCategoryDTO saveCategoryDTO)
        {
            var category = new Categories 
            {
               categoryName = saveCategoryDTO.categoryName,
            };

            await _categoryRepository.AddRepository(category);
        }

        public async Task putUpdateServices(SaveCategoryDTO saveCategoryDTO)
        {
            var category = await _categoryRepository.GetByIdRepository(saveCategoryDTO.id);
            category.categoryName = saveCategoryDTO.categoryName;
            
            await _categoryRepository.UpdateRepository(category);
        }

        public async Task deleteServices(int id)
        {
            var custumer = await _categoryRepository.GetByIdRepository(id);
            await _categoryRepository.DeleteRepository(custumer);
        }
    }
}
