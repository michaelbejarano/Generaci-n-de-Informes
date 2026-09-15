// Implementations/PagoService.cs
using generacionDeInformes.Models;
using generacionDeInformes.Services.Interfaces;
using generacionDeInformes.UnitOfWork;

namespace generacionDeInformes.Services.Implementations
{
    public class PagoService : IPagoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PagoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Pago>> GetAllAsync()
        {
            return await _unitOfWork.PagoRepository.GetAllAsync();
        }

        public async Task<Pago?> GetByIdAsync(int id)
        {
            return await _unitOfWork.PagoRepository.GetByIdAsync(id);
        }

        public async Task<Pago> CreateAsync(Pago entity)
        {
            await _unitOfWork.PagoRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(Pago entity)
        {
            var existing = await _unitOfWork.PagoRepository.GetByIdAsync(entity.PagoId);
            if (existing == null) return false;

            _unitOfWork.PagoRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _unitOfWork.PagoRepository.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.PagoRepository.Delete(existing);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}