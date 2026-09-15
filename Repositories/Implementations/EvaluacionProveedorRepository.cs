// Repositories/Implementations/EvaluacionProveedorRepository.cs
using generacionDeInformes.Models;
using generacionDeInformes.Repositories.Interfaces;

namespace generacionDeInformes.Repositories.Implementations
{
    public class EvaluacionProveedorRepository : GenericRepository<EvaluacionesProveedore>, IEvaluacionProveedorRepository
    {
        public EvaluacionProveedorRepository(ViajesContext context) : base(context) { }
    }
}