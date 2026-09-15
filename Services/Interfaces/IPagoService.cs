// Interfaces/IPagoService.cs
using generacionDeInformes.Models;

namespace generacionDeInformes.Services.Interfaces
{
    public interface IPagoService
    {
        Task<IEnumerable<Pago>> GetAllAsync();
        Task<Pago?> GetByIdAsync(int id);
        Task<Pago> CreateAsync(Pago entity);
        Task<bool> UpdateAsync(Pago entity);
        Task<bool> DeleteAsync(int id);
    }
}