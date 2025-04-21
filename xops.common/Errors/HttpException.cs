using System;
using System.Net;

namespace xops.common.Errors;

public class HttpException : Exception
{
    public HttpStatusCode StatusCode {get;}
    public HttpException(string message, HttpStatusCode statusCode):base(message){
        StatusCode = statusCode;
    }

}

public class NotFoundException : HttpException
{
    public NotFoundException(string message="No se encontro resultado") : base(message, HttpStatusCode.NotFound)
    {
    }
}
public class UnAuthorizedException : HttpException{
    public UnAuthorizedException(string message = "Accion no permitida"): base(message, HttpStatusCode.Unauthorized){}
}
public class BadRequestException : HttpException
{
    public BadRequestException(string message) : base(message, System.Net.HttpStatusCode.BadRequest) { }

}