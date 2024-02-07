using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Common.Consul;

public static class ConsulRegistration
{
    public static IServiceCollection AddConsulConfigure(this IServiceCollection Services,IConfiguration configuration)
    {

        Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consolconfig =>
        {
            var address = configuration["Consul:Address"];
            consolconfig.Address = new Uri(address);

        }));

        return Services;
    }

    public static IApplicationBuilder RegisterWithConsul(this IApplicationBuilder app, IHostApplicationLifetime lifetime,string ServiceName,string Url)
    {
        
        var ConsulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
        Console.WriteLine(Url);
        var uri = new Uri(Url);
        
        var registration = new AgentServiceRegistration()
        {
            ID = ServiceName,
            Name = ServiceName,
            Address = uri.Host,
            Port = uri.Port,
            Tags = new []{ ServiceName}


        };

        ConsulClient.Agent.ServiceRegister(registration).Wait();
        lifetime.ApplicationStopping.Register(() =>
        {
            ConsulClient.Agent.ServiceDeregister(registration.ID).Wait();
        });
        return app;
    }
    
    
    
}