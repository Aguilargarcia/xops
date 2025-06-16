using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using xops.marca.core.Entities;
using xops.marca.logic.Database;

namespace xops.marca.api;

public static class ServiceCollectionExtension
{
    public static void AddMarcaModule(this IServiceCollection services, IConfiguration config){
        var connection = config.GetConnectionString("Connection");
        services.AddDbContext<MarcaDbContext>(opts => opts.UseSqlServer(connection));
        var builder = services.AddIdentityCore<Marca>();
        builder = new IdentityBuilder(builder.UserType, builder.Services);
        builder.AddRoles<IdentityRole>();
        builder.AddEntityFrameworkStores<MarcaDbContext>();
    }

}
