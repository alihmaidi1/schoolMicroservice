using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
namespace Admin;

public static class DependencyInjection
{
    public static IServiceCollection AddAdmindependency(this IServiceCollection services)
    {


        
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }

    
}