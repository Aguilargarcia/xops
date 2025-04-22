using System;
using xops.common.Entities;

namespace xops.inventario.core.Entities;

public class Categoria : Entity
{
    public string Nombre {get; set;}

    public Categoria(string nombre){
        Nombre = nombre;
    }

}
