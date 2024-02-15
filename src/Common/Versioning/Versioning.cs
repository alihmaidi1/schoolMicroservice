using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Versioning;

public static class Versioning
{

    public static IServiceCollection AddVersioning(this IServiceCollection services)
    {


        services.AddApiVersioning(option =>
        {

            option.DefaultApiVersion = new ApiVersion(1,0);
            option.ReportApiVersions = true;
            option.AssumeDefaultVersionWhenUnspecified = true;
            option.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("x-api-version"),
                new MediaTypeApiVersionReader("x-api-version"));

        });



        return services;
    }
    
}