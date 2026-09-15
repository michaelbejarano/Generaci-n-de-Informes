// Repositories/Implementations/ItinerarioRepository.cs
using generacionDeInformes.Models;
using generacionDeInformes.Repositories.Interfaces;

namespace generacionDeInformes.Repositories.Implementations
{
    public class ItinerarioRepository : GenericRepository<Itinerario>, IItinerarioRepository
    {
        public ItinerarioRepository(ViajesContext context) : base(context) { }
    }
}