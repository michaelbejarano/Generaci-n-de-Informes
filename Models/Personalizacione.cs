using System;
using System.Collections.Generic;

namespace generacionDeInformes.Models;

public partial class Personalizacione
{
    public int PersonalizacionId { get; set; }

    public int ReservaId { get; set; }

    public string Preferencia { get; set; } = null!;

    public string? Detalle { get; set; }

    public virtual Reserva Reserva { get; set; } = null!;
}
