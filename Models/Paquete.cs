using System;
using System.Collections.Generic;

namespace generacionDeInformes.Models;

public partial class Paquete
{
    public int PaqueteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Destino { get; set; } = null!;

    public decimal Precio { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int Capacidad { get; set; }

    public int Disponible { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Itinerario> Itinerarios { get; set; } = new List<Itinerario>();

    public virtual ICollection<PaqueteServicio> PaqueteServicios { get; set; } = new List<PaqueteServicio>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
