// Implementations/EvaluacionProveedorService.cs
using generacionDeInformes.Models;
using generacionDeInformes.Services.Interfaces;
using generacionDeInformes.UnitOfWork;

namespace generacionDeInformes.Services.Implementations
{
    public class EvaluacionProveedorService : IEvaluacionProveedorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EvaluacionProveedorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EvaluacionesProveedore>> GetAllAsync()
        {
            return await _unitOfWork.EvaluacionProveedorRepository.GetAllAsync();
        }

        public async Task<EvaluacionesProveedore?> GetByIdAsync(int id)
        {
            return await _unitOfWork.EvaluacionProveedorRepository.GetByIdAsync(id);
        }

        public async Task<EvaluacionesProveedore> CreateAsync(EvaluacionesProveedore entity)
        {
            await _unitOfWork.EvaluacionProveedorRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(EvaluacionesProveedore entity)
        {
            var existing = await _unitOfWork.EvaluacionProveedorRepository.GetByIdAsync(entity.EvaluacionId);
            if (existing == null) return false;

            _unitOfWork.EvaluacionProveedorRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _unitOfWork.EvaluacionProveedorRepository.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.EvaluacionProveedorRepository.Delete(existing);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}