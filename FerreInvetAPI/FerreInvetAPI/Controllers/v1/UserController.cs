using Microsoft.AspNetCore.Mvc;
using Source.Core.Application.DTO.User;
using Source.Core.Application.Helpers;
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
        public async Task<IActionResult> Get(string nickNameOrEmail, string password)
        {
            var userValidation =  await _userServices.getLoggingService(nickNameOrEmail, password);

            if (userValidation.Item2.IsError) 
            {
                return BadRequest(userValidation.Item2);
            }

            //TODO: VALIDATED SESSION FOR ALL ENDPOINTS
            //HttpContext.Session.Set<UserDTO>("userDTO", userValidation.Item1);
            return Ok(userValidation.Item1);
        }


        [HttpPost]
        public async Task<IActionResult> Post(UserRegisterDTO user)
        {
            var isUserCreate = await _userServices.postCreateServices(user);

            if (isUserCreate.IsError) 
            {
                return BadRequest(isUserCreate);
            }

            return NoContent();
        }
    }
}
