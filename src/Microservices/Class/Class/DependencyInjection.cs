using System.Reflection;
using FluentValidation;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Class;

public static class DependencyInjection
{
    
    public static IServiceCollection AddClass(this IServiceCollection services,IConfiguration configuration)
    {
        
        
        
        
        
        services.AddMassTransit(config =>
        {

            
            config.UsingRabbitMq((context, configure) =>
            {
                configure.Host(configuration["Rabbitmq"]);
                
            });
            
            
        });
        services.AddOptions<MassTransitHostOptions>().Configure(options =>
        {
            
            
            

        });
        
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;

        
    }
    
}