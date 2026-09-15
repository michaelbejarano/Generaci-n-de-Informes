// Repositories/Implementations/PaqueteRepository.cs
using generacionDeInformes.Models;
using generacionDeInformes.Repositories.Interfaces;

namespace generacionDeInformes.Repositories.Implementations
{
    public class PaqueteRepository : GenericRepository<Paquete>, IPaqueteRepository
    {
        public PaqueteRepository(ViajesContext context) : base(context) { }
    }
}