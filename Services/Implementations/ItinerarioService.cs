// Implementations/ItinerarioService.cs
using generacionDeInformes.Models;
using generacionDeInformes.Services.Interfaces;
using generacionDeInformes.UnitOfWork;

namespace generacionDeInformes.Services.Implementations
{
    public class ItinerarioService : IItinerarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItinerarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Itinerario>> GetAllAsync()
        {
            return await _unitOfWork.ItinerarioRepository.GetAllAsync();
        }

        public async Task<Itinerario?> GetByIdAsync(int id)
        {
            return await _unitOfWork.ItinerarioRepository.GetByIdAsync(id);
        }

        public async Task<Itinerario> CreateAsync(Itinerario entity)
        {
            await _unitOfWork.ItinerarioRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(Itinerario entity)
        {
            var existing = await _unitOfWork.ItinerarioRepository.GetByIdAsync(entity.ItinerarioId);
            if (existing == null) return false;

            _unitOfWork.ItinerarioRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _unitOfWork.ItinerarioRepository.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.ItinerarioRepository.Delete(existing);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}