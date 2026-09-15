// Implementations/ServicioService.cs
using generacionDeInformes.Models;
using generacionDeInformes.Services.Interfaces;
using generacionDeInformes.UnitOfWork;

namespace generacionDeInformes.Services.Implementations
{
    public class ServicioService : IServicioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Servicio>> GetAllAsync()
        {
            return await _unitOfWork.ServicioRepository.GetAllAsync();
        }

        public async Task<Servicio?> GetByIdAsync(int id)
        {
            return await _unitOfWork.ServicioRepository.GetByIdAsync(id);
        }

        public async Task<Servicio> CreateAsync(Servicio entity)
        {
            await _unitOfWork.ServicioRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(Servicio entity)
        {
            var existing = await _unitOfWork.ServicioRepository.GetByIdAsync(entity.ServicioId);
            if (existing == null) return false;

            _unitOfWork.ServicioRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _unitOfWork.ServicioRepository.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.ServicioRepository.Delete(existing);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}