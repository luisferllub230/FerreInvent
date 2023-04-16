using Microsoft.AspNetCore.Mvc;
using Source.Core.Application.DTO.ErrorMessage;
using Source.Core.Application.DTO.Inventory;
using Source.Core.Application.DTO.Sales;
using Source.Core.Application.Interfaces.Services;
using Source.Core.Domain.Entities;

namespace FerreInvetAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SalesController : BaseAapiController
    {

        private readonly ISalesServices _services;

        public SalesController(ISalesServices salesServices)
        {
            _services = salesServices;
        }

        //TODO: FALTA CONFIGURAR MEJOR LOS ENDPOINTS
        [HttpGet]
        public async Task<IActionResult> get()
        {
            var isSales = await _services.getAllServices();

            if (isSales.Item2.IsError)
            {
                return NotFound(isSales.Item2);
            }

            return Ok(isSales.Item1);
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
        public async Task<IActionResult> Post(SaveSalesDTO saveSalesDTO)
        {
            await _services.postCreateServices(saveSalesDTO);
            return NoContent();
        }


        [HttpPut]
        public async Task<IActionResult> Put(SaveSalesDTO saveSalesDTO)
        {
            var error = new ErrorMessageDTO();

            if (saveSalesDTO == null || saveSalesDTO.id <= 0)
            {
                error.IsError = true;
                error.ErrorMessage = "not inventory id or inventory data";
                return BadRequest(error);
            }

            await _services.putUpdateServices(saveSalesDTO);
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
