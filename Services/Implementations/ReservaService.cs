// Implementations/ReservaService.cs
using generacionDeInformes.Models;
using generacionDeInformes.Services.Interfaces;
using generacionDeInformes.UnitOfWork;

namespace generacionDeInformes.Services.Implementations
{
    public class ReservaService : IReservaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            return await _unitOfWork.ReservaRepository.GetAllAsync();
        }

        public async Task<Reserva?> GetByIdAsync(int id)
        {
            return await _unitOfWork.ReservaRepository.GetByIdAsync(id);
        }

        public async Task<Reserva> CreateAsync(Reserva entity)
        {
            await _unitOfWork.ReservaRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(Reserva entity)
        {
            var existing = await _unitOfWork.ReservaRepository.GetByIdAsync(entity.ReservaId);
            if (existing == null) return false;

            _unitOfWork.ReservaRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _unitOfWork.ReservaRepository.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.ReservaRepository.Delete(existing);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}