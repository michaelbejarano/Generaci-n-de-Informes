using System;
using System.Collections.Generic;

namespace generacionDeInformes.Models;

public partial class EvaluacionesProveedore
{
    public int EvaluacionId { get; set; }

    public int ProveedorId { get; set; }

    public int? ReservaId { get; set; }

    public int Puntuacion { get; set; }

    public string? Comentario { get; set; }

    public DateTime? FechaEvaluacion { get; set; }

    public virtual Proveedore Proveedor { get; set; } = null!;

    public virtual Reserva? Reserva { get; set; }
}
