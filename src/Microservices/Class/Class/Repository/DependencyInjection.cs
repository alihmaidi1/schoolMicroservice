using System.Reflection;
using Class.Repository.Base;
using Class.Repository.Bill;
using Class.Repository.Class;
using Class.Repository.ClassYear;
using Class.Repository.Parent;
using Class.Repository.Semester;
using Class.Repository.Stage;
using Class.Repository.Year;
using Common;
using Common.Email;
using Common.Entity.Interface;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Class.Repository;

public static class DependencyInjection
{
    
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {



        services.Scan(selector=>
            selector.FromAssemblies(Assembly.GetExecutingAssembly(),
                    CommonAssymbly.CommonAssemblyConst)
                .AddClasses(c=>c.AssignableTo(typeof(basesuper)))
                .AsSelfWithInterfaces()
                .WithTransientLifetime()
        );
        // services.AddTransient<IMailService, MailService>();
        return services;
        
    }

    
}