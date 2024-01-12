using System.Reflection;
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
        return services;

        
    }

    
}