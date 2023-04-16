using Source.Core.Application.DTO.ErrorMessage;
using Source.Core.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Application.Interfaces.Services
{
    public interface IUserServices
    {
        public Task<ErrorMessageDTO> postCreateServices(UserRegisterDTO userDTO);
        public Task<(UserDTO, ErrorMessageDTO)> getLoggingService(string nickNameOrEmail, string password);
    }
}
