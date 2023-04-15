using Microsoft.EntityFrameworkCore;
using Source.Core.Application.DTO;
using Source.Core.Application.Interfaces.Repository;
using Source.Core.Domain.Entities;
using Source.Infraestructure.Persistence.Context;

namespace Source.Infraestructure.Persistence.Repositories
{
    public class UserRepository : GeneryRepository<User>, IUserRepository
    {
        private readonly AplicationContext _aplicationContext;

        public UserRepository(AplicationContext context) : base(context)
        {
            _aplicationContext = context;
        }

        public async Task<User> GetByUserNickNameOrEmail(string nickNameOrEmail) 
        {
           var user =  await _aplicationContext.Set<User>().FirstOrDefaultAsync( e => e.userNickname == nickNameOrEmail || e.userEmail == nickNameOrEmail);

           return user;
        }
    }
}
