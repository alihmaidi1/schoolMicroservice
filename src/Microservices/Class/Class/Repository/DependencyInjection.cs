using System.Reflection;
using Class.Repository.Bill;
using Class.Repository.Class;
using Class.Repository.ClassYear;
using Class.Repository.Stage;
using Class.Repository.Year;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Class.Repository;

public static class DependencyInjection
{
    
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {


        services.AddTransient<IStageRepository,StageRepository>();
        services.AddTransient<IYearRepository,YearRepository>();
        services.AddTransient<IClassRepository,ClassRepository>();
        services.AddTransient<IBillRepository,Billrepository>();

        services.AddTransient<IClassYearRepository,ClassYearRepository>();
        return services;

        
    }

    
}