using System.Reflection;
using Common.Entity.Interface;
using Domain.Repository.Base;
using Domain.Repository.Vacation;
using Domain.Repository.Warning;
using Domain.Repository.Year;
using Microsoft.Extensions.DependencyInjection;
using Repository.Teacher;
using Teacher.Repository.Teacher;

namespace Domain.Repository;

public static class dependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
     
        
        services.Scan(selector=>
            selector.FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(c=>c.AssignableTo(typeof(basesuper)))
                .AsSelfWithInterfaces()
                .WithScopedLifetime()
        );
        return services;
    }
}