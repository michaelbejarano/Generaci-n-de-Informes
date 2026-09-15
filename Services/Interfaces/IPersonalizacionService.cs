// Services/Interfaces/IPersonalizacionService.cs
using generacionDeInformes.Models;

namespace generacionDeInformes.Services.Interfaces
{
    public interface IPersonalizacionService
    {
        Task<IEnumerable<Personalizacione>> GetAllAsync();
        Task<Personalizacione?> GetByIdAsync(int id);
        Task<Personalizacione> CreateAsync(Personalizacione entity);
        Task<bool> UpdateAsync(Personalizacione entity);
        Task<bool> DeleteAsync(int id);
    }
}