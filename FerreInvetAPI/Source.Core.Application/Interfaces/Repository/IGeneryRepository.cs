﻿

using Source.Core.Domain.ICommon;

namespace Source.Core.Application.Interfaces.Repository
{
    public interface IGeneryRepository<Entity> where Entity : class
    {
        public Task AddRepository(Entity entity);
        public Task UpdateRepository(Entity entity);
        public Task DeleteRepository(Entity entity);
        public Task<List<Entity>> GetAllRepository();
        public Task<Entity> GetByIdRepository(int id);
        public Task<List<Entity>> GetAllWhitIncluedeRepository(List<string> properties);
        public Task<Entity> GetByIdWhitIncludeRepository<Entity>(int id, List<string> properties) where Entity : class, IdEntityCommon;

    }
}
