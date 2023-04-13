using Source.Core.Application.DTO;
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
    }
}
