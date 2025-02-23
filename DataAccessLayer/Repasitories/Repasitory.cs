using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.IRepasitories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DataAccessLayer.Repasitories
{
    public class Repasitory<TEntity> : IRepasitory<TEntity> where TEntity : class
    {
        private readonly AppDbContext _appDbContext;

        public Repasitory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(TEntity entity)
        => await _appDbContext.Set<TEntity>().AddAsync(entity);

        public async Task DeleteAsync(int id)
        {
            var entity = await _appDbContext.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _appDbContext.Remove(entity);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await _appDbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(int id)
        => await _appDbContext.Set<TEntity>().FindAsync(id);

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Argument null bo'lib qoldi !");
            }
            _appDbContext.Set<TEntity>().Update(entity); 
        }
    }
}
