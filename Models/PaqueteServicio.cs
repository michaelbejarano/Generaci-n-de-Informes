using System;
using System.Collections.Generic;

namespace generacionDeInformes.Models;

public partial class PaqueteServicio
{
    public int PaqueteId { get; set; }

    public int ServicioId { get; set; }

    public int? Cantidad { get; set; }

    public virtual Paquete Paquete { get; set; } = null!;

    public virtual Servicio Servicio { get; set; } = null!;
}
