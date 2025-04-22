using System;
using xops.inventario.core.Entities;

namespace xops.inventario.core.Dto;

public class ProductoDto
{
    public Guid Id {get; set;}
    public string Nombre{get;set;}
    public Guid MarcaId {get; set;}
    public decimal Precio {get; set;}
    public int Stock {get; set;}
    public Categoria Categoria {get; set;}

}
