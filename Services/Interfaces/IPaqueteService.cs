// Interfaces/IPaqueteService.cs
using generacionDeInformes.Models;

namespace generacionDeInformes.Services.Interfaces
{
    public interface IPaqueteService
    {
        Task<IEnumerable<Paquete>> GetAllAsync();
        Task<Paquete?> GetByIdAsync(int id);
        Task<Paquete> CreateAsync(Paquete entity);
        Task<bool> UpdateAsync(Paquete entity);
        Task<bool> DeleteAsync(int id);
    }
}