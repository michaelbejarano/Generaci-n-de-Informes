// Interfaces/IServicioService.cs
using generacionDeInformes.Models;

namespace generacionDeInformes.Services.Interfaces
{
    public interface IServicioService
    {
        Task<IEnumerable<Servicio>> GetAllAsync();
        Task<Servicio?> GetByIdAsync(int id);
        Task<Servicio> CreateAsync(Servicio entity);
        Task<bool> UpdateAsync(Servicio entity);
        Task<bool> DeleteAsync(int id);
    }
}