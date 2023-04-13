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


        public async Task<List<User>> getAllServices()
        {
            return await _userRepository.GetAllRepository();
        }

        public async Task<User> getByIdServices(int id)
        {
            return await _userRepository.GetByIdRepository(id);
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

        //public async Task<Inventory> putUpdateServices(Inventory inventory)
       // {
           // await _userRepository.UpdateRepository(inventory);

           // return await _userRepository.GetByIdRepository(inventory.id);
        //}

        public async Task deleteServices(int id)
        {
            var repository = await _userRepository.GetByIdRepository(id);
            await _userRepository.DeleteRepository(repository);
        }
    }
}
