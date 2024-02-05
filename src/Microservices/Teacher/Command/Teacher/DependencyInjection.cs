using System.Reflection;
using Common.Rabbitmq;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using MassTransit.MultiBus;
using Microsoft.Extensions.Configuration;
using Teacher.EventBusConsumer;
using Teacher.EventBusConsumer.Admin;

namespace Teacher;

public static class DependencyInjection
{
    public static IServiceCollection AddTeacher(this IServiceCollection services,IConfiguration configuration)
    {
        
        
        services.AddMassTransit(config =>
        {

            config.AddConsumer<AddAdminConsumer>();

            config.AddConsumer<UpdateAdminConsumer>();

            config.UsingRabbitMq((context, configure) =>
            {
                configure.Host(configuration["Rabbitmq"]);
                configure.ReceiveEndpoint(EventBusConstants.AdminQueue, c =>
                {
                    c.ConfigureConsumer<AddAdminConsumer>(context);
                    c.ConfigureConsumer<UpdateAdminConsumer>(context);
                    
                });
                
            });
            services.AddScoped<AddAdminConsumer>();
            


        });
        

        services.AddOptions<MassTransitHostOptions>().Configure(options =>
        {
            
            
            
        
        });

        
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;

        
    }

}