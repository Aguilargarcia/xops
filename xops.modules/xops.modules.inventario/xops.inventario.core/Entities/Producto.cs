using System;
using xops.common.Entities;

namespace xops.inventario.core.Entities;

public class Producto:Entity
{
    public string Nombre {get; set;}
    public Categoria Categoria {get;set;}
    public decimal Precio {get; set;}
    public int Stock {get; set;}
    public Guid Marca {get; set;}
    public string MarcaNombre {get; set;}


}
