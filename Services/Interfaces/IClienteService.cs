// Interfaces/IClienteService.cs
using generacionDeInformes.Models;

namespace generacionDeInformes.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task<Cliente> CreateAsync(Cliente entity);
        Task<bool> UpdateAsync(Cliente entity);
        Task<bool> DeleteAsync(int id);
    }
}