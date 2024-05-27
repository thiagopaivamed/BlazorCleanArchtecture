using BlazorServerCleanArchtecture.Application.Interfaces.Repositories;
using BlazorServerCleanArchtecture.Domain.Common;
using BlazorServerCleanArchtecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerCleanArchtecture.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseAuditableEntity
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IQueryable<TEntity> Entities => _applicationDbContext.Set<TEntity>();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _applicationDbContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(TEntity entity)
        {
            _applicationDbContext.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _applicationDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int entityId)
        {
            return await _applicationDbContext.Set<TEntity>().FindAsync(entityId);
        }

        public Task UpdateAsync(TEntity entity)
        {
            TEntity entityOnDatabase = _applicationDbContext.Set<TEntity>().Find(entity.Id);
            _applicationDbContext.Entry(entityOnDatabase).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }
    }
}
