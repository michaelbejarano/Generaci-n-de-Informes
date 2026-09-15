// Repositories/Interfaces/IPaqueteServicioRepository.cs
using generacionDeInformes.Models;

namespace generacionDeInformes.Repositories.Interfaces
{
    public interface IPaqueteServicioRepository : IGenericRepository<PaqueteServicio>
    {
        Task<PaqueteServicio?> GetByIdAsync(int paqueteId, int servicioId);
        Task<bool> ExistsAsync(int paqueteId, int servicioId);
    }
}