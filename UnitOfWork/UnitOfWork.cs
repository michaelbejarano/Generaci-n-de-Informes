// UnitOfWork/UnitOfWork.cs

using generacionDeInformes.Models;
using generacionDeInformes.Repositories.Implementations;
using generacionDeInformes.Repositories.Interfaces;

namespace generacionDeInformes.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ViajesContext _context;

        private IClienteRepository? _clienteRepository;
        private IProveedorRepository? _proveedorRepository;
        private IPaqueteRepository? _paqueteRepository;
        private IItinerarioRepository? _itinerarioRepository;
        private IServicioRepository? _servicioRepository;
        private IPaqueteServicioRepository? _paqueteServicioRepository;
        private IReservaRepository? _reservaRepository;
        private IPagoRepository? _pagoRepository;
        private IPersonalizacionRepository? _personalizacionRepository;
        private IEvaluacionProveedorRepository? _evaluacionProveedorRepository;

        public UnitOfWork(ViajesContext context)
        {
            _context = context;
        }

        public IClienteRepository ClienteRepository =>
            _clienteRepository ??= new ClienteRepository(_context);

        public IProveedorRepository ProveedorRepository =>
            _proveedorRepository ??= new ProveedorRepository(_context);

        public IPaqueteRepository PaqueteRepository =>
            _paqueteRepository ??= new PaqueteRepository(_context);

        public IItinerarioRepository ItinerarioRepository =>
            _itinerarioRepository ??= new ItinerarioRepository(_context);

        public IServicioRepository ServicioRepository =>
            _servicioRepository ??= new ServicioRepository(_context);

        public IPaqueteServicioRepository PaqueteServicioRepository =>
            _paqueteServicioRepository ??= new PaqueteServicioRepository(_context);

        public IReservaRepository ReservaRepository =>
            _reservaRepository ??= new ReservaRepository(_context);

        public IPagoRepository PagoRepository =>
            _pagoRepository ??= new PagoRepository(_context);

        public IPersonalizacionRepository PersonalizacionRepository =>
            _personalizacionRepository ??= new PersonalizacionRepository(_context);

        public IEvaluacionProveedorRepository EvaluacionProveedorRepository =>
            _evaluacionProveedorRepository ??= new EvaluacionProveedorRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}