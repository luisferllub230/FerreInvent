using Microsoft.AspNetCore.Mvc;
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
            var inventories = await _services.getAllServices();

            if (inventories == null || inventories.Count == 0)
            {
                return NotFound();
            }

            return Ok(inventories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> get(int id)
        {
            var inventory = await _services.getByIdServices(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        //TODO: NEED DTO
        [HttpPost]
        public async Task<IActionResult> Post(Inventory inventory)
        {
            //TODO: NEED VALIDATION
            await _services.postCreateServices(inventory);

            return NoContent();
        }

        //TODO: NEED DTO
        [HttpPut]
        public async Task<IActionResult> Put(Inventory inventory) 
        {
            if (inventory.id == null || inventory.id <= 0)
            {
                return BadRequest();
            }
            
            var newInventory = await _services.putUpdateServices(inventory);

            return Ok(newInventory);
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
