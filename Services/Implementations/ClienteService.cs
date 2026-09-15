// Implementations/ClienteService.cs
using generacionDeInformes.Models;
using generacionDeInformes.Services.Interfaces;
using generacionDeInformes.UnitOfWork;

namespace generacionDeInformes.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _unitOfWork.ClienteRepository.GetAllAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _unitOfWork.ClienteRepository.GetByIdAsync(id);
        }

        public async Task<Cliente> CreateAsync(Cliente entity)
        {
            await _unitOfWork.ClienteRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(Cliente entity)
        {
            var existing = await _unitOfWork.ClienteRepository.GetByIdAsync(entity.ClienteId);
            if (existing == null) return false;

            _unitOfWork.ClienteRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _unitOfWork.ClienteRepository.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.ClienteRepository.Delete(existing);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}