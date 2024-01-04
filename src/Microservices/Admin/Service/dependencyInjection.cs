using Microsoft.Extensions.DependencyInjection;
using Service.Manager.Auth;

namespace Service;

public static class dependencyInjection
{


    public static IServiceCollection AddServices(this IServiceCollection services)
    {


        services.AddTransient<IAuthService, AuthService>();

        return services;


    }


}