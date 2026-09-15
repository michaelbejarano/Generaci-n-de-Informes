// Interfaces/IPaqueteServicioService.cs
using generacionDeInformes.Models;

namespace generacionDeInformes.Services.Interfaces
{
    public interface IPaqueteServicioService
    {
        Task<IEnumerable<PaqueteServicio>> GetAllAsync();
        Task<PaqueteServicio?> GetByIdAsync(int paqueteId, int servicioId);
        Task<PaqueteServicio> CreateAsync(PaqueteServicio entity);
        Task<bool> UpdateAsync(PaqueteServicio entity);
        Task<bool> DeleteAsync(int paqueteId, int servicioId);
    }
}