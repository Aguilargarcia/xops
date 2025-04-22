using System;
using xops.common.Interfaces;
using xops.inventario.core.Dto;
using xops.inventario.core.Entities;

namespace xops.inventario.core.Interfaces;

public interface IInventarioService
{
    Task<ProductoDto> GetProductoByID(Guid Id);
    Task DeleteProductById(Guid Id);
    Task<IReadOnlyCollection<ProductoDto>> GetProductosByCategoria(Guid categoriaId);
    Task<IReadOnlyCollection<ProductoDto>> GetProductos();
    Task<Producto> AddProducto(ProductoDto productoDto);
    Task<Producto> UpdateProducto(ProductoDto productoDto);
    Task<Categoria> AddCategoria(CategoriaDto categoria);
    Task<Categoria> UpdateCategoria(Guid categoriaId, CategoriaDto categoria);
    Task<Categoria> GetCategoria(Guid categoriaId);
    Task<IReadOnlyCollection<Categoria>> GetCategorias();

}
