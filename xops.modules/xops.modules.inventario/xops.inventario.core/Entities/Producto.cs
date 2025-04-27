using xops.common.Entities;

namespace xops.inventario.core.Entities;



public class Producto: Entity
{
    public string Nombre {get; set;}
    public string Genero {get; set;}
    public string Tipo {get; set;}
    public Guid CategoriaId {get; private set;}
    public Categoria Categoria {get; private set;}
    public decimal Precio {get; private set;}
    public int Stock {get; private set;}
    public Guid MarcaId {get; init;}
    public IReadOnlyCollection<Talla> Tallas {get; set;}

    protected Producto(){}
    public Producto(string nombre, Guid marcaId, decimal precio, Categoria categoria){
        Nombre = nombre;
        MarcaId = marcaId;
        Precio = precio;
        Categoria = categoria;
    }
    public void SetNombre(string nombre){
        if(string.IsNullOrEmpty(nombre)){
            throw new InvalidOperationException("Nombre no puede ser null");
        }
        Nombre = nombre;
    }
    public void SetCategoria(Categoria categoria){
        if(categoria is null){
            throw new InvalidOperationException("Categoria no puede ser null");
        }
        CategoriaId  = categoria.Id;
        Categoria = categoria;
    }
    public void SetPrecio(decimal precio){
        if(precio <= 0){
            throw new InvalidOperationException("Precio debe ser mayor a 0");
        }
        Precio = precio;
    }

    public void SetStock(int stock){
        if(stock < 0){
            throw new InvalidOperationException("Stock debe ser un numero entero");
        }
        Stock = stock;
    }

    public void DecreaseStock(int cantidad){
        Stock--;
    }


}
