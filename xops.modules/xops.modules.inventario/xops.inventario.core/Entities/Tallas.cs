using System;
using xops.common.Entities;

namespace xops.inventario.core.Entities;

public class Talla : Entity
{
    
    public Guid ProductoId {get; set;}
    public string Nombre {get ;set;}
}
