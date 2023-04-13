using Source.Core.Application.DTO;
using Source.Core.Application.Interfaces.Repository;
using Source.Core.Application.Interfaces.Services;
using Source.Core.Domain.Entities;

namespace Source.Core.Application.Services
{
    internal class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository repository)
        {
            _userRepository = repository;
        }

        //TODO: IMPLEMENT PASSWORD ENCRIPTED 
        public async Task<(UserDTO, ErrorMessageDTO)> getLoggingService(string nickNameOrEmail, string password) 
        {
            var errorMessage = new ErrorMessageDTO();
            var user = await _userRepository.GetByUserNickNameOrEmail(nickNameOrEmail);

            if (user == null || user.userPassword != password) 
            {
                errorMessage.IsError = true;
                errorMessage.ErrorMessage = "ERROR: Check your email or password";
                return (null, errorMessage);
            }

            var userDTO = new UserDTO();
            userDTO.position = user.position;
            userDTO.Id = user.id;
            userDTO.name = user.name;
            userDTO.userEmail = user.userEmail;
            userDTO.userNickname = user.userNickname;

            return (userDTO, errorMessage);
        }

        public async Task<ErrorMessageDTO> postCreateServices(UserRegisterDTO userDTO)
        {
            var errorMessage = new ErrorMessageDTO();

            errorMessage.IsError = false;

            if (userDTO.UserEmail == null || userDTO.UserPassword == null ) 
            {
                errorMessage.IsError = true;
                errorMessage.ErrorMessage = "user email or password null";
                return errorMessage;
            }

            if (userDTO.UserPassword != userDTO.UserConfirmPassword) 
            {
                errorMessage.IsError = true;
                errorMessage.ErrorMessage = "password and confirm password are not equal";
                return errorMessage;
            }

            //TODO: IMPLEMENT PASSWORD ENCRIPTED
            var user = new User();
            user.name = userDTO.UserNickName;
            user.userPassword = userDTO.UserPassword;
            user.position = userDTO.position;
            user.userNickname = userDTO.UserNickName;

            await _userRepository.AddRepository(user);

            return errorMessage;
        }
    }
}
