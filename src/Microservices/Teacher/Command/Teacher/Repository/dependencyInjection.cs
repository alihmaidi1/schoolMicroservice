using Domain.Repository.Warning;
using Microsoft.Extensions.DependencyInjection;
using Repository.Teacher;
using Teacher.Repository.Teacher;

namespace Domain.Repository;

public static class dependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
     
        services.AddTransient<ITeacherRepository, TeacherRepository>();
        services.AddTransient<IManagerRepository, ManagerRepository>();

        services.AddTransient<IWarningRepository, WarningRepository>();
        
        return services;

    }
}