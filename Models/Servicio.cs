using System;
using System.Collections.Generic;

namespace generacionDeInformes.Models;

public partial class Servicio
{
    public int ServicioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? ProveedorId { get; set; }

    public virtual ICollection<PaqueteServicio> PaqueteServicios { get; set; } = new List<PaqueteServicio>();

    public virtual Proveedore? Proveedor { get; set; }
}
