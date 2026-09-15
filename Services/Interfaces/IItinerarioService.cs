// Interfaces/IItinerarioService.cs
using generacionDeInformes.Models;

namespace generacionDeInformes.Services.Interfaces
{
    public interface IItinerarioService
    {
        Task<IEnumerable<Itinerario>> GetAllAsync();
        Task<Itinerario?> GetByIdAsync(int id);
        Task<Itinerario> CreateAsync(Itinerario entity);
        Task<bool> UpdateAsync(Itinerario entity);
        Task<bool> DeleteAsync(int id);
    }
}