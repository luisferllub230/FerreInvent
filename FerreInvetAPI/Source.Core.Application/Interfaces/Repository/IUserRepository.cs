using Source.Core.Application.DTO;
using Source.Core.Domain.Entities;

namespace Source.Core.Application.Interfaces.Repository
{
    public interface IUserRepository : IGeneryRepository<User>
    {
        public Task<User> GetByUserNickNameOrEmail(string nickNameOrEmail);
    }
}
