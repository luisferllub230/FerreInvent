using Source.Core.Application.DTO.Categories;
using Source.Core.Application.DTO.Custumer;
using Source.Core.Application.DTO.ErrorMessage;
using Source.Core.Domain.ICommon;

namespace Source.Core.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        public Task<(List<CategoryDTO>, ErrorMessageDTO)> getAllServices();
        public Task<(CategoryDTO, ErrorMessageDTO)> getByIdServices(int id);
        public Task postCreateServices(SaveCategoryDTO saveCategoryDTO);
        public Task putUpdateServices(SaveCategoryDTO saveCategoryDTO);
        public Task deleteServices(int id);
    }
}
