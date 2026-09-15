// Repositories/Implementations/PagoRepository.cs
using generacionDeInformes.Models;
using generacionDeInformes.Repositories.Interfaces;

namespace generacionDeInformes.Repositories.Implementations
{
    public class PagoRepository : GenericRepository<Pago>, IPagoRepository
    {
        public PagoRepository(ViajesContext context) : base(context) { }
    }
}