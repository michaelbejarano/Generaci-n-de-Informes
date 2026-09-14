using System;
using System.Collections.Generic;

namespace generacionDeInformes.Models;

public partial class Itinerario
{
    public int ItinerarioId { get; set; }

    public int PaqueteId { get; set; }

    public int Dia { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual Paquete Paquete { get; set; } = null!;
}
