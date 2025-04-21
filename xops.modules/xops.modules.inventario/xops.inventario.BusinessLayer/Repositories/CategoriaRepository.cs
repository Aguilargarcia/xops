using System;
using xops.common.Repository;
using xops.inventario.businesslayer.Database;
using xops.inventario.core.Entities;

namespace xops.inventario.businesslayer.Repositories;

public class CategoriaRepository : BaseRepository<Categoria>
{
    public CategoriaRepository(InventarioDbContext context) : base(context) { }

}
