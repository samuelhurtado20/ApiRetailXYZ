using ApiRetailXYZ.Data.Models;
using ApiRetailXYZ.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiRetailXYZ.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RetailXyzContext _context;
        private DbSet<T> _dbSet;

        public Repository(RetailXyzContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Delete(Guid id)
        {
            T entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IEnumerable<T> Get()
        {
            return _dbSet.ToList();
        }

        public async Task<T> Get(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

    }
}
