using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClassInfrutructure;

public static class DependencyInjection
{
    
    public static IServiceCollection AddInfrustucture(this IServiceCollection services, IConfiguration configuration)
    {

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