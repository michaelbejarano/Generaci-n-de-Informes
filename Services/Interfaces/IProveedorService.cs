// Services/Interfaces/IProveedorService.cs
using generacionDeInformes.Models;

namespace generacionDeInformes.Services.Interfaces
{
    public interface IProveedorService
    {
        Task<IEnumerable<Proveedore>> GetAllAsync();
        Task<Proveedore?> GetByIdAsync(int id);
        Task<Proveedore> CreateAsync(Proveedore entity);
        Task<bool> UpdateAsync(Proveedore entity);
        Task<bool> DeleteAsync(int id);
    }
}