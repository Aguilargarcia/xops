using System.Net;
using System.Text.Json;
using xops.common.Errors;

namespace xops.api.midelwares;

public class ExceptionMidelware
{

    private readonly ILogger<ExceptionMidelware> _logger;
    private readonly RequestDelegate _next;

    public ExceptionMidelware(ILogger<ExceptionMidelware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext ctx)
    {
        try
        {
            await _next(ctx);
        }
        catch (System.Exception e)
        {
            var response = ctx.Response;
            response.ContentType = "application/json";
            var error = new Error { };

            switch (e)
            {
                case HttpException http:
                    error.Message = http.Message;
                    error.Code = (int)HttpStatusCode.BadRequest;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    error.Message = "Internal Server Error";
                    error.Code = (int)HttpStatusCode.InternalServerError;
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var json = JsonSerializer.Serialize(error);
            await response.WriteAsync(json);
        }
    }

}


public class Error
{
    public int Code { get; set; }
    public string Message { get; set; }
}