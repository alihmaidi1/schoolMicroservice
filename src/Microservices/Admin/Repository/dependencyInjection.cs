using Common.Email;
using Common.Redis;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Manager.Admin;
using Repository.Manager.Jwt;
using Repository.Manager.Jwt.Factory;

namespace Repository;

public static class dependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services,IConfiguration configuration)
    {

        services.AddHangfire(x => x.UseSqlServerStorage(configuration["ConnectionStrings:DefaultConnection"]));
        services.AddHangfireServer();
        services.AddTransient<ICacheRepository,CacheRepository>();
        services.AddTransient<IAdminRepository,AdminRepository>();
        // services.AddTransient<IJwtRepository,JwtRepository>();
        services.AddTransient<IMailService, MailService>();
        services.AddTransient<ISchemaFactory, SchemaFactory>();
        // services.AddTransient<IAdminRefreshTokenRepository,AdminRefreshTokenRepository>();

        return services;

        
    }

}