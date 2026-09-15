// UnitOfWork/IUnitOfWork.cs
using generacionDeInformes.Repositories.Interfaces;

namespace generacionDeInformes.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository ClienteRepository { get; }
        IProveedorRepository ProveedorRepository { get; }
        IPaqueteRepository PaqueteRepository { get; }
        IItinerarioRepository ItinerarioRepository { get; }
        IServicioRepository ServicioRepository { get; }
        IPaqueteServicioRepository PaqueteServicioRepository { get; }
        IReservaRepository ReservaRepository { get; }
        IPagoRepository PagoRepository { get; }
        IPersonalizacionRepository PersonalizacionRepository { get; }
        IEvaluacionProveedorRepository EvaluacionProveedorRepository { get; }

        Task<int> SaveChangesAsync();
    }
}