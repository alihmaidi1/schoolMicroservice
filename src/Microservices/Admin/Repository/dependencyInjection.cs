using Common.Redis;
using Microsoft.Extensions.DependencyInjection;
using Repository.Manager.Admin;
using Repository.Manager.Jwt;

namespace Repository;

public static class dependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {

        services.AddTransient<ICacheRepository,CacheRepository>();
        services.AddTransient<IAdminRepository,AdminRepository>();
        services.AddTransient<IJwtRepository,JwtRepository>();
        // services.AddTransient<IAdminRefreshTokenRepository,AdminRefreshTokenRepository>();

        return services;

        
    }

}