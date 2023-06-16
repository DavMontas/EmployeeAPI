using Employee.Core.Application.Interfaces.Repositories;
using Employee.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        public GenericRepository(AppDbContext db)
        {
            _db = db;
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }


        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity, int id)
        {
            T entry = await _db.Set<T>().FindAsync(id);
            _db.Entry(entry).CurrentValues.SetValues(entity);
            await _db.SaveChangesAsync();
        }
    }
}
