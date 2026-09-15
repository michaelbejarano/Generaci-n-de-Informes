// Interfaces/IReservaService.cs
using generacionDeInformes.Models;

namespace generacionDeInformes.Services.Interfaces
{
    public interface IReservaService
    {
        Task<IEnumerable<Reserva>> GetAllAsync();
        Task<Reserva?> GetByIdAsync(int id);
        Task<Reserva> CreateAsync(Reserva entity);
        Task<bool> UpdateAsync(Reserva entity);
        Task<bool> DeleteAsync(int id);
    }
}