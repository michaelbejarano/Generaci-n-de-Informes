// Services/Implementations/ProveedorService.cs
using generacionDeInformes.Models;
using generacionDeInformes.Services.Interfaces;
using generacionDeInformes.UnitOfWork;

namespace generacionDeInformes.Services.Implementations
{
    public class ProveedorService : IProveedorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProveedorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Proveedore>> GetAllAsync()
        {
            return await _unitOfWork.ProveedorRepository.GetAllAsync();
        }

        public async Task<Proveedore?> GetByIdAsync(int id)
        {
            return await _unitOfWork.ProveedorRepository.GetByIdAsync(id);
        }

        public async Task<Proveedore> CreateAsync(Proveedore entity)
        {
            await _unitOfWork.ProveedorRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(Proveedore entity)
        {
            var existing = await _unitOfWork.ProveedorRepository.GetByIdAsync(entity.ProveedorId);
            if (existing == null) return false;

            _unitOfWork.ProveedorRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _unitOfWork.ProveedorRepository.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.ProveedorRepository.Delete(existing);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}