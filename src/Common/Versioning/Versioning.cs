using Asp.Versioning;
using Common.Swagger;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Versioning;

public static class Versioning
{

    public static IServiceCollection AddVersioning(this IServiceCollection services)
    {


        services.AddApiVersioning(option =>
        {

            option.AssumeDefaultVersionWhenUnspecified = true;
            option.DefaultApiVersion = new ApiVersion(1,0);

            option.ReportApiVersions = true;
            option.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("x-api-version"),
                new HeaderApiVersionReader("x-api-version"),
                new MediaTypeApiVersionReader("x-api-version"));

        }).AddApiExplorer(option =>
        {

            
        });

        


        return services;
    }
    
}