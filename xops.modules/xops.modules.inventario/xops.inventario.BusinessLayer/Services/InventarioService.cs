using System;
using System.Collections.ObjectModel;
using AutoMapper;
using xops.common.Errors;
using xops.inventario.core.Dto;
using xops.inventario.core.Entities;
using xops.inventario.core.Interfaces;

namespace xops.inventario.BusinessLayer.Services;

public class InventarioService : IInventarioService
{
    private readonly IProductoRepository _productRepository;
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IMapper _autoMapper;
    public InventarioService(IProductoRepository productRepository, IMapper autoMapper, ICategoriaRepository categoriaRepository){
        _autoMapper = autoMapper;
        _categoriaRepository=categoriaRepository;
        _productRepository = productRepository;
    }

    private void validateChanges(int results){
        if(results == 0){
            throw new BadRequestException("No se pudieron guardar los cambios");
        }
    }

    public async Task<Producto> AddProducto(ProductoDto productoDto)
    {
        Producto producto = _autoMapper.Map<Producto>(productoDto);
        producto.SetStock(productoDto.Stock);
        producto.SetPrecio(productoDto.Precio);

        int result = await _productRepository.AddAsync(producto);
        this.validateChanges(result);
        return producto;       
        
    }

    public async Task<IReadOnlyCollection<ProductoDto>> GetProductos()
    {
        IReadOnlyCollection<Producto> productos = await _productRepository.GetAllAsync();
        IReadOnlyCollection<ProductoDto> list = _autoMapper.Map<IReadOnlyCollection<ProductoDto>>(productos);
        return list;
    }

    public async Task<ProductoDto> GetProductoByID(Guid Id)
    {
        Producto producto = await _productRepository.GetByIdAsync(Id);
        ProductoDto dto = _autoMapper.Map<ProductoDto>(producto);
        return dto;
    }

    public Task<IReadOnlyCollection<ProductoDto>> GetProductosByCategoria(Guid categoriaId)
    {
        throw new NotImplementedException();
    }

    public async Task<Producto> UpdateProducto(ProductoDto productoDto)
    {
        Producto producto = await _productRepository.GetByIdAsync(productoDto.Id);
        if(producto is null){
            throw new NotFoundException("El producto no existe actulamente");
        }
        producto.SetNombre(productoDto.Nombre);
        producto.SetStock(productoDto.Stock);
        producto.SetPrecio(productoDto.Precio);
        // producto.SetCategoria(productoDto.Categoria);
        var result = await _productRepository.UpdateAsync(producto);
        this.validateChanges(result);
        
        return producto;

    }

    public async Task<Categoria> AddCategoria(CategoriaDto categoria)
    {
        Categoria _categoria = _autoMapper.Map<Categoria>(categoria);
        var result = await _categoriaRepository.AddAsync(_categoria);
        this.validateChanges(result);
        return _categoria;
    }

    public async Task<Categoria> UpdateCategoria(Guid categoriaId,CategoriaDto categoria)
    {
        Categoria curr = await GetCategoria(categoriaId);
        if(curr is null){
            throw new NotFoundException();
        }
        curr.Nombre = categoria.Nombre;
        var results = await _categoriaRepository.UpdateAsync(curr);
        this.validateChanges(results);
        return curr;
    }

    public async Task<Categoria> GetCategoria(Guid guid)
    {
        Categoria categoria = await _categoriaRepository.GetByIdAsync(guid);
        if(categoria is null){
            throw new NotFoundException();
        }
        return categoria;
    }

    public async Task<IReadOnlyCollection<Categoria>> GetCategorias()
    {
        IReadOnlyCollection<Categoria> categorias  = await _categoriaRepository.GetAllAsync();
        return categorias;
    }

    public async Task DeleteProductById(Guid Id)
    {
        Producto producto = await _productRepository.GetByIdAsync(Id);
        if(producto is null){
            throw new NotFoundException();
        }
        await _productRepository.RemoveAsync(producto);

    }
}
