// Services/Implementations/PersonalizacionService.cs
using generacionDeInformes.Models;
using generacionDeInformes.Services.Interfaces;
using generacionDeInformes.UnitOfWork;

namespace generacionDeInformes.Services.Implementations
{
    public class PersonalizacionService : IPersonalizacionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonalizacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Personalizacione>> GetAllAsync()
        {
            return await _unitOfWork.PersonalizacionRepository.GetAllAsync();
        }

        public async Task<Personalizacione?> GetByIdAsync(int id)
        {
            return await _unitOfWork.PersonalizacionRepository.GetByIdAsync(id);
        }

        public async Task<Personalizacione> CreateAsync(Personalizacione entity)
        {
            await _unitOfWork.PersonalizacionRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(Personalizacione entity)
        {
            var existing = await _unitOfWork.PersonalizacionRepository.GetByIdAsync(entity.PersonalizacionId);
            if (existing == null) return false;

            _unitOfWork.PersonalizacionRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _unitOfWork.PersonalizacionRepository.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.PersonalizacionRepository.Delete(existing);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}