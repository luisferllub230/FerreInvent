using Microsoft.AspNetCore.Mvc;
using Source.Core.Application.DTO.Categories;
using Source.Core.Application.DTO.Custumer;
using Source.Core.Application.DTO.ErrorMessage;
using Source.Core.Application.DTO.Inventory;
using Source.Core.Application.DTO.Sales;
using Source.Core.Application.Interfaces.Services;
using Source.Core.Domain.Entities;

namespace FerreInvetAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoryController : BaseAapiController
    {

        private readonly ICategoryService _services;

        public CategoryController(ICategoryService categoryService)
        {
            _services = categoryService;
        }

        //TODO: FALTA CONFIGURAR MEJOR LOS ENDPOINTS
        [HttpGet]
        public async Task<IActionResult> get()
        {
            var isCategory = await _services.getAllServices();

            if (isCategory.Item2.IsError)
            {
                return NotFound(isCategory.Item2);
            }

            return Ok(isCategory.Item1);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> get(int id)
        {
            var category = await _services.getByIdServices(id);

            if (category.Item2.IsError)
            {
                return NotFound(category.Item2);
            }

            return Ok(category.Item1);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SaveCategoryDTO saveCategoryDTO)
        {
            await _services.postCreateServices(saveCategoryDTO);
            return NoContent();
        }


        [HttpPut]
        public async Task<IActionResult> Put(SaveCategoryDTO saveCategoryDTO)
        {
            var error = new ErrorMessageDTO();

            if (saveCategoryDTO == null || saveCategoryDTO.id <= 0)
            {
                error.IsError = true;
                error.ErrorMessage = "not custumer id or inventory data";
                return BadRequest(error);
            }

            await _services.putUpdateServices(saveCategoryDTO);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }

            await _services.deleteServices(id);
            return NoContent();
        }
    }
}
