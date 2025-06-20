using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using xops.user.businesslayer.Context;
namespace xops.user.api.ServiceCollectionExtensions;

public static class ServicesCollectionExtension
{

    public static void AddUserModule(this IServiceCollection services, IConfiguration configuration)
    {

    }



}
