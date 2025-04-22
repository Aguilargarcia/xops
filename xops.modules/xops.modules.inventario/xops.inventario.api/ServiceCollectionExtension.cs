using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using xops.inventario.businesslayer.Database;
using xops.inventario.businesslayer.Repositories;
using xops.inventario.BusinessLayer.Services;
using xops.inventario.core.Interfaces;
using xops.inventario.core.Profiles;

public static class ServiceCollectionExtensions{
    public static void AddInventarioModule(this IServiceCollection services, IConfiguration configuration){
        var connectionString = configuration.GetConnectionString("InventarioConnection");
        services.AddDbContext<InventarioDbContext>(opts=> opts.UseSqlServer(connectionString));
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddTransient<IProductoRepository, ProductoRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<IInventarioService, InventarioService>();
    }
}