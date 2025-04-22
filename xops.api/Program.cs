using xops.common;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenApi();
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.AddCommonServices();
        builder.Services.AddInventarioModule(builder.Configuration);

        var app = builder.Build();

        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.Run();
    }
}