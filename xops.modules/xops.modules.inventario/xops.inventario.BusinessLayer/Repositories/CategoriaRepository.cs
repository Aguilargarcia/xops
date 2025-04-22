using System;
using xops.common.Repository;
using xops.inventario.businesslayer.Database;
using xops.inventario.core.Entities;
using xops.inventario.core.Interfaces;

namespace xops.inventario.businesslayer.Repositories;

public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(InventarioDbContext context) : base(context) { }

}
