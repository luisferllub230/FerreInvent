﻿using Microsoft.EntityFrameworkCore;
using Source.Core.Application.Interfaces.Repository;
using Source.Core.Domain.ICommon;
using Source.Infraestructure.Persistence.Context;

namespace Source.Infraestructure.Persistence.Repositories
{
    public class GeneryRepository<Entity> : IGeneryRepository<Entity> where Entity : class 
    {

        private readonly AplicationContext _aplicationContext;

        public GeneryRepository(AplicationContext aplication) 
        {
            _aplicationContext = aplication;
        }

        public async Task AddRepository(Entity entity) 
        {
            await _aplicationContext.Set<Entity>().AddAsync(entity);
            await _aplicationContext.SaveChangesAsync();
        }

        public async Task UpdateRepository(Entity entity) 
        {
            _aplicationContext.Entry(entity).State = EntityState.Modified;
            await _aplicationContext.SaveChangesAsync();
        }

        public async Task DeleteRepository(Entity entity) 
        {
            _aplicationContext.Set<Entity>().Remove(entity);
            await _aplicationContext.SaveChangesAsync();
        }

        public async Task<List<Entity>> GetAllRepository() 
        {
            return await _aplicationContext.Set<Entity>().ToListAsync();
        }

        public async Task<List<Entity>> GetAllWhitIncluedeRepository(List<string> properties)
        {
            var query = _aplicationContext.Set<Entity>().AsQueryable();

            foreach (string property in properties) 
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();
        }

        public async Task<Entity> GetByIdWhitIncludeRepository<Entity>(int id, List<string> properties) where Entity : class, IdEntityCommon
        {
            var query = _aplicationContext.Set<Entity>().Where(e => e.id == id).AsQueryable();

            foreach (string property in properties)
            {
                query = query.Include(property);
            }

            return query.FirstOrDefault();
        }

        public async Task<Entity> GetByIdRepository(int id) 
        {
            return await _aplicationContext.Set<Entity>().FindAsync(id); 
        }
    }
}
