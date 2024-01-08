using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Common.Opentelemetry;

public static class DependencyInjection
{

    public static IServiceCollection AddteleMetry(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddOpenTelemetry().WithTracing(builder => builder
        
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddSource(configuration["AppName"])
            .SetResourceBuilder(ResourceBuilder.CreateDefault()
            
                .AddService(configuration["AppName"])
            )
            
            .AddConsoleExporter()
            .AddOtlpExporter(option =>
            {
                     option.Endpoint = new Uri("http://jaeger:4317");
            })
        );
        
        return services;

    }




}