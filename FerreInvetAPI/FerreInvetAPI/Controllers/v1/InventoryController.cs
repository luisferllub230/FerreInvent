using Microsoft.AspNetCore.Mvc;
using Source.Core.Application.DTO;
using Source.Core.Application.Interfaces.Services;
using Source.Core.Domain.Entities;

namespace FerreInvetAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InventoryController : BaseAapiController
    {

        private readonly IInventoryServices _services;

        public InventoryController(IInventoryServices inventoryServices)
        {
            _services = inventoryServices;
        }

        //TODO: FALTA CONFIGURAR MEJOR LOS ENDPOINTS
        [HttpGet]
        public async Task<IActionResult> get()
        {
            var isInventory = await _services.getAllServices();

            if (isInventory.Item2.IsError)
            {
                return NotFound(isInventory.Item2);
            }

            return Ok(isInventory.Item1);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> get(int id)
        {
            var inventory = await _services.getByIdServices(id);

            if (inventory.Item2.IsError)
            {
                return NotFound(inventory.Item2);
            }

            return Ok(inventory.Item1);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SaveInventoryDTO saveInventoryDTO)
        {
            await _services.postCreateServices(saveInventoryDTO);
            return NoContent();
        }

        //TODO: NEED DTO
        [HttpPut]
        public async Task<IActionResult> Put(SaveInventoryDTO saveInventoryDTO) 
        {
            var error = new ErrorMessageDTO();

            if (saveInventoryDTO == null || saveInventoryDTO.id <= 0)
            {
                error.IsError = true;
                error.ErrorMessage = "not inventory id or inventory data";
                return BadRequest(error);
            }
            
            await _services.putUpdateServices(saveInventoryDTO);
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
