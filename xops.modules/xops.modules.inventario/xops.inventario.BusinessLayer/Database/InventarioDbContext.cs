using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using xops.inventario.core.Entities;

namespace xops.inventario.businesslayer.Database;

public class InventarioDbContext : DbContext
{
    public InventarioDbContext(DbContextOptions<InventarioDbContext> opts) : base(opts) { }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Categoria> Categorias {get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }


}
