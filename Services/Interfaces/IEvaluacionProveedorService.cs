// Interfaces/IEvaluacionProveedorService.cs
using generacionDeInformes.Models;

namespace generacionDeInformes.Services.Interfaces
{
    public interface IEvaluacionProveedorService
    {
        Task<IEnumerable<EvaluacionesProveedore>> GetAllAsync();
        Task<EvaluacionesProveedore?> GetByIdAsync(int id);
        Task<EvaluacionesProveedore> CreateAsync(EvaluacionesProveedore entity);
        Task<bool> UpdateAsync(EvaluacionesProveedore entity);
        Task<bool> DeleteAsync(int id);
    }
}