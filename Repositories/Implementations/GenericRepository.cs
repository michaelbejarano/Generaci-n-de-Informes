// Repositories/Implementations/GenericRepository.cs
using generacionDeInformes.Models;
using generacionDeInformes.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace generacionDeInformes.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ViajesContext _context; // reemplaza TuDbContext por el nombre real que generó el scaffold
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ViajesContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}