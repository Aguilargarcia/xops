using System;
using Microsoft.Extensions.DependencyInjection;
using xops.common.Interfaces;
using xops.common.Repository;

namespace xops.common;

public static class ServiceCollectionExtension
{
    public static void AddCommonServices(this IServiceCollection services){
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
    }

}
