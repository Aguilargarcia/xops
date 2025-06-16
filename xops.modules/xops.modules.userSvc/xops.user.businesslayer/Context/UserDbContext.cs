using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using xops.user.core.Entities;
namespace xops.user.businesslayer.Context;

public class UserDbContext : IdentityDbContext<User>
{

    public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
