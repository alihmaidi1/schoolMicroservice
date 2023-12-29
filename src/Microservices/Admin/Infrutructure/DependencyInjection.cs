using Infrutructure.Authorization.Handlers;
using Infrutructure.Authorization.Providers;
using Infrutructure.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrutructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrustucture(this IServiceCollection services, IConfiguration configuration)
    {


        services.AddTransient<IAuthorizationPolicyProvider,PermissionProvider>();
        services.AddTransient<IAuthorizationHandler,PermissionAuthorizationHandler>();
        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option
                // .UseLazyLoadingProxies()                
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));                
            // option.LogTo(Console.WriteLine,LogLevel.Information);
            option.EnableSensitiveDataLogging();                                
            
        });



        return services;
    }

    
}