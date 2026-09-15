// Repositories/Implementations/ProveedorRepository.cs
using generacionDeInformes.Models;
using generacionDeInformes.Repositories.Interfaces;

namespace generacionDeInformes.Repositories.Implementations
{
    public class ProveedorRepository : GenericRepository<Proveedore>, IProveedorRepository
    {
        public ProveedorRepository(ViajesContext context) : base(context) { }
    }
}