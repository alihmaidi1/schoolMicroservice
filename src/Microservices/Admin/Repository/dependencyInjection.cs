using System.Reflection;
using Common;
using Common.Email;
using Common.Entity.Interface;
using Common.Redis;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Base;
using Repository.Manager.Admin;
using Repository.Manager.Jwt;
using Repository.Manager.Jwt.Factory;
using Repository.Manager.Role;

namespace Repository;

public static class dependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services,IConfiguration configuration)
    {

        services.AddHangfire(x => x.UseSqlServerStorage(configuration["ConnectionStrings:DefaultConnection"]));
        services.AddHangfireServer();
        services.Scan(selector=>
            selector.FromAssemblies(Assembly.GetExecutingAssembly(),
                    CommonAssymbly.CommonAssemblyConst)
                .AddClasses(c=>c.AssignableTo(typeof(basesuper)))
                .AsSelfWithInterfaces()
                .WithTransientLifetime()
        );
        return services;

        
    }

}