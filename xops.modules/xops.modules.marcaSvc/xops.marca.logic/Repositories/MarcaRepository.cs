using System;
using Microsoft.EntityFrameworkCore;
using xops.common.Repository;
using xops.marca.core.Entities;
using xops.marca.core.Interfaces;
using xops.marca.logic.Database;

namespace xops.marca.logic.Repositories;

public class MarcaRepository : SecurityRepository<Marca>, IMarcaRepository
{
    public MarcaRepository(MarcaDbContext context):base(context){}

}
