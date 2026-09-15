// Repositories/Implementations/PaqueteServicioRepository.cs
using generacionDeInformes.Models;
using generacionDeInformes.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace generacionDeInformes.Repositories.Implementations
{
    public class PaqueteServicioRepository : GenericRepository<PaqueteServicio>, IPaqueteServicioRepository
    {
        public PaqueteServicioRepository(ViajesContext context) : base(context) { }

        public async Task<PaqueteServicio?> GetByIdAsync(int paqueteId, int servicioId)
        {
            return await _dbSet.FirstOrDefaultAsync(ps => ps.PaqueteId == paqueteId && ps.ServicioId == servicioId);
        }

        public async Task<bool> ExistsAsync(int paqueteId, int servicioId)
        {
            return await _dbSet.AnyAsync(ps => ps.PaqueteId == paqueteId && ps.ServicioId == servicioId);
        }
    }
}