// Implementations/PaqueteService.cs
using generacionDeInformes.Models;
using generacionDeInformes.Services.Interfaces;
using generacionDeInformes.UnitOfWork;

namespace generacionDeInformes.Services.Implementations
{
    public class PaqueteService : IPaqueteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaqueteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Paquete>> GetAllAsync()
        {
            return await _unitOfWork.PaqueteRepository.GetAllAsync();
        }

        public async Task<Paquete?> GetByIdAsync(int id)
        {
            return await _unitOfWork.PaqueteRepository.GetByIdAsync(id);
        }

        public async Task<Paquete> CreateAsync(Paquete entity)
        {
            await _unitOfWork.PaqueteRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(Paquete entity)
        {
            var existing = await _unitOfWork.PaqueteRepository.GetByIdAsync(entity.PaqueteId);
            if (existing == null) return false;

            _unitOfWork.PaqueteRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _unitOfWork.PaqueteRepository.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.PaqueteRepository.Delete(existing);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}