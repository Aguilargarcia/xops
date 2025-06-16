using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using xops.marca.core.Entities;

namespace xops.marca.logic.Database;

public class MarcaDbContext : IdentityDbContext<Marca>
{
    public MarcaDbContext(DbContextOptions<MarcaDbContext> opts):base(opts){}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}


