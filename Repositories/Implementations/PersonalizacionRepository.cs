// Repositories/Implementations/PersonalizacionRepository.cs
using generacionDeInformes.Models;
using generacionDeInformes.Repositories.Interfaces;

namespace generacionDeInformes.Repositories.Implementations
{
    public class PersonalizacionRepository : GenericRepository<Personalizacione>, IPersonalizacionRepository
    {
        public PersonalizacionRepository(ViajesContext context) : base(context) { }
    }
}