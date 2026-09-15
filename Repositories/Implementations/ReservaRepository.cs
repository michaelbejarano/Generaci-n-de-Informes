// Repositories/Implementations/ReservaRepository.cs
using generacionDeInformes.Models;
using generacionDeInformes.Repositories.Interfaces;

namespace generacionDeInformes.Repositories.Implementations
{
    public class ReservaRepository : GenericRepository<Reserva>, IReservaRepository
    {
        public ReservaRepository(ViajesContext context) : base(context) { }
    }
}