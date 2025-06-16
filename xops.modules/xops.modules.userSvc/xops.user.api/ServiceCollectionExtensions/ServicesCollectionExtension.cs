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
using xops.user.businesslayer.Services;
using xops.user.core.Entities;
using xops.user.core.Interfaces;

namespace xops.user.api.ServiceCollectionExtensions;

public static class ServicesCollectionExtension
{

    public static IServiceCollection AddUserModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("UserConnection");
        services.AddDbContext<UserDbContext>(opts => opts.UseSqlServer(connection));
        services.TryAddSingleton<ITokenService, TokenService>();
        var builder = services.AddIdentityCore<User>();
        builder = new IdentityBuilder(builder.UserType, builder.Services);
        builder.AddRoles<IdentityRole>();
        builder.AddEntityFrameworkStores<UserDbContext>();
        builder.AddSignInManager<SignInManager<User>>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts=>
        {
            opts.UseSecurityTokenValidators = true;
            opts.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["token:key"])),
                ValidIssuer = "yo",
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateAudience = true
            };
        });

        services.AddAuthorization();

        return services;

    }



}
