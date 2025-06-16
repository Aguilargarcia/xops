using xops.common;
using xops.user.api.ServiceCollectionExtensions;
using xops.marca.api;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenApi();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCommonServices();
        builder.Services.AddUserModule(builder.Configuration);
        builder.Services.AddInventarioModule(builder.Configuration);
        builder.Services.AddMarcaModule(builder.Configuration);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        var app = builder.Build();

        app.MapOpenApi();
        app.UseSwagger();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    }
}