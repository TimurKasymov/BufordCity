using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BufordCity.DAL.Entities;
using BufordCity.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BufordCity.DAL.Repositories
{
    /// <summary>
    /// Класс, который используется для работы с БД через EF Core
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TType"></typeparam>
    public class DbRepository<TEntity, TType> : IDbRepository<TEntity> where TEntity : BaseEntity<TType>
    {
        private readonly DbContext _dbContext;

        public DbRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateManyAsync(List<TEntity> entity)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entity);
        }
    }
}
