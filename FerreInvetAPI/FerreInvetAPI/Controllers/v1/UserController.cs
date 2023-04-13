using Microsoft.AspNetCore.Mvc;
using Source.Core.Application.DTO;
using Source.Core.Application.Interfaces.Services;
using Source.Core.Domain.Entities;

namespace FerreInvetAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseAapiController
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices services)
        {
            _userServices = services;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return NoContent();
        }


        //TODO: NEED DTO
        [HttpPost]
        public async Task<IActionResult> Post(UserRegisterDTO user)
        {
            var isUserCreate = await _userServices.postCreateServices(user);

            if (isUserCreate.IsError) 
            {
                //TODO: NEED TO SPECIFY THE ERROR
                return BadRequest();
            }

            return NoContent();
        }


        
    }
}
