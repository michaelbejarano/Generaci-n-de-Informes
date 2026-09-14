using System;
using System.Collections.Generic;

namespace generacionDeInformes.Models;

public partial class Reserva
{
    public int ReservaId { get; set; }

    public int ClienteId { get; set; }

    public int PaqueteId { get; set; }

    public DateTime? FechaReserva { get; set; }

    public int CantidadPersonas { get; set; }

    public decimal Total { get; set; }

    public string? Estado { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<EvaluacionesProveedore> EvaluacionesProveedores { get; set; } = new List<EvaluacionesProveedore>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Paquete Paquete { get; set; } = null!;

    public virtual ICollection<Personalizacione> Personalizaciones { get; set; } = new List<Personalizacione>();
}
