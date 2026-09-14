using System;
using System.Collections.Generic;

namespace generacionDeInformes.Models;

public partial class Pago
{
    public int PagoId { get; set; }

    public int ReservaId { get; set; }

    public DateTime? FechaPago { get; set; }

    public decimal Monto { get; set; }

    public string MetodoPago { get; set; } = null!;

    public string? Estado { get; set; }

    public virtual Reserva Reserva { get; set; } = null!;
}
