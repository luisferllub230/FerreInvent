using Microsoft.AspNetCore.Mvc;
using Source.Core.Application.DTO.Custumer;
using Source.Core.Application.DTO.ErrorMessage;
using Source.Core.Application.DTO.Inventory;
using Source.Core.Application.DTO.Sales;
using Source.Core.Application.Interfaces.Services;
using Source.Core.Domain.Entities;

namespace FerreInvetAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustumerController : BaseAapiController
    {

        private readonly ICustumerServices _services;

        public CustumerController(ICustumerServices custumerServices)
        {
            _services = custumerServices;
        }

        //TODO: FALTA CONFIGURAR MEJOR LOS ENDPOINTS
        [HttpGet]
        public async Task<IActionResult> get()
        {
            var isCustumer = await _services.getAllServices();

            if (isCustumer.Item2.IsError)
            {
                return NotFound(isCustumer.Item2);
            }

            return Ok(isCustumer.Item1);
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
        public async Task<IActionResult> Post(SaveCustumerDTO saveCustumerDTO)
        {
            await _services.postCreateServices(saveCustumerDTO);
            return NoContent();
        }


        [HttpPut]
        public async Task<IActionResult> Put(SaveCustumerDTO saveCustumerDTO)
        {
            var error = new ErrorMessageDTO();

            if (saveCustumerDTO == null || saveCustumerDTO.id <= 0)
            {
                error.IsError = true;
                error.ErrorMessage = "not custumer id or inventory data";
                return BadRequest(error);
            }

            await _services.putUpdateServices(saveCustumerDTO);
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
