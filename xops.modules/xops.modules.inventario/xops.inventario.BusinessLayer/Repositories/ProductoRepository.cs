using System;
using Microsoft.EntityFrameworkCore;
using xops.common.Repository;
using xops.inventario.businesslayer.Database;
using xops.inventario.core.Entities;
using xops.inventario.core.Interfaces;

namespace xops.inventario.businesslayer.Repositories;

public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
{
    private readonly InventarioDbContext _context;
    public ProductoRepository(InventarioDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IReadOnlyCollection<Producto>> GetAllAsync()
    {
        return await _context.Productos.Include(x=>x.Categoria).ToListAsync();
    }

    public override async Task<Producto> GetByIdAsync(Guid Id)
    {
        return await _context.Productos.Include(p=>p.Categoria).FirstOrDefaultAsync(p=>p.Id==Id);
    }
    

}
