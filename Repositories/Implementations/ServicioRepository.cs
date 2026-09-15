// Repositories/Implementations/ServicioRepository.cs
using generacionDeInformes.Models;
using generacionDeInformes.Repositories.Interfaces;

namespace generacionDeInformes.Repositories.Implementations
{
    public class ServicioRepository : GenericRepository<Servicio>, IServicioRepository
    {
        public ServicioRepository(ViajesContext context) : base(context) { }
    }
}