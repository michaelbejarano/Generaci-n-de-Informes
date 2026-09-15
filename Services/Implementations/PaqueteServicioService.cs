// Implementations/PaqueteServicioService.cs
using generacionDeInformes.Models;
using generacionDeInformes.Services.Interfaces;
using generacionDeInformes.UnitOfWork;

namespace generacionDeInformes.Services.Implementations
{
    public class PaqueteServicioService : IPaqueteServicioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaqueteServicioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PaqueteServicio>> GetAllAsync()
        {
            return await _unitOfWork.PaqueteServicioRepository.GetAllAsync();
        }

        public async Task<PaqueteServicio?> GetByIdAsync(int paqueteId, int servicioId)
        {
            return await _unitOfWork.PaqueteServicioRepository.GetByIdAsync(paqueteId, servicioId);
        }

        public async Task<PaqueteServicio> CreateAsync(PaqueteServicio entity)
        {
            await _unitOfWork.PaqueteServicioRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(PaqueteServicio entity)
        {
            var existing = await _unitOfWork.PaqueteServicioRepository.GetByIdAsync(entity.PaqueteId, entity.ServicioId);
            if (existing == null) return false;

            _unitOfWork.PaqueteServicioRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int paqueteId, int servicioId)
        {
            var existing = await _unitOfWork.PaqueteServicioRepository.GetByIdAsync(paqueteId, servicioId);
            if (existing == null) return false;

            _unitOfWork.PaqueteServicioRepository.Delete(existing);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}