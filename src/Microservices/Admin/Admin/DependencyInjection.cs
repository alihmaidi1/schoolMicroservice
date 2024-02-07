using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MassTransit;
using MassTransit.MultiBus;
using Microsoft.Extensions.Configuration;

namespace Admin;

public static class DependencyInjection
{
    public static IServiceCollection AddAdmindependency(this IServiceCollection services,IConfiguration configuration)
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