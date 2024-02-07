using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Common.Swagger;

using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

public  static class DependencyInjection
{
       public static IServiceCollection AddOpenApi(this IServiceCollection services,string name,string title,string version,string description)
        {

            services.AddSwaggerGen(option =>
            {


                //create  swagger document

                    var openApiInfo = new OpenApiInfo();
                    openApiInfo.Title = title;
                    openApiInfo.Version = version;
                    openApiInfo.Description = description;
                    option.SwaggerDoc(name, openApiInfo);




                option.CustomSchemaIds(x => x.FullName);

                option.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme()
                {

                    Description = "JWT Authorization header using the Bearer scheme. Example: Authorization: Bearer {token}",
                    Type=SecuritySchemeType.Http,
                    In= ParameterLocation.Header,
                    Name = "Authorization",
                    Scheme = "Bearer",

                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {

                              Reference = new OpenApiReference
                              {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                              }


                        },
                        new string[]{}


                    }


                });


            });

            return services;

        }
        public static IApplicationBuilder ConfigureOpenAPI(this IApplicationBuilder app,string name)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                    c.SwaggerEndpoint($"/swagger/{name}/swagger.json",  name);                    
             
                c.DocExpansion(DocExpansion.None);
                

            });
            return app;
        }

 
    
}