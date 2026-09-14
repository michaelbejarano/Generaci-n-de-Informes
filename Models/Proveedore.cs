using System;
using System.Collections.Generic;

namespace generacionDeInformes.Models;

public partial class Proveedore
{
    public int ProveedorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public decimal? Calificacion { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<EvaluacionesProveedore> EvaluacionesProveedores { get; set; } = new List<EvaluacionesProveedore>();

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
