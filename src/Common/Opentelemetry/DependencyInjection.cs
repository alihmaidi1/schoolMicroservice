using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Common.Opentelemetry;

public static class DependencyInjection
{

    public static IServiceCollection AddteleMetry(this IServiceCollection services)
    {
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            // .AddJaegerExporter()
            .AddOtlpExporter()
            .Build();
        

        return services;

    }




}