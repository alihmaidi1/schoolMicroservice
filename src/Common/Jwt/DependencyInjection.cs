using System.Text;
using Common.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Common.Jwt;

public static class DependencyInjection
{

    
    public static IServiceCollection AddJwtConfigration(this IServiceCollection services, IConfiguration Configuration,string main,params string[] schemas)
    {
        

        var Authentication=services.AddAuthentication(options =>
        {
            
            options.DefaultAuthenticateScheme = main;
            options.DefaultChallengeScheme = main;
            options.DefaultScheme = main;
            
        });

        
        
        foreach(var SchmeaName in schemas)
        {
            var JwtOption = Configuration.GetSection(SchmeaName.ToString());

            Authentication.AddJwtBearer(SchmeaName.ToString(), options =>
            {
                // options.Authority="asfsd"
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = JwtOption["Issuer"],
                    ValidAudience = JwtOption["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOption["Key"]))


                };
                options.Events = new JwtBearerEvents
                {
                    
                    OnChallenge = async context =>
                    {
                        context.HandleResponse();
                    
                        throw new UnAuthenticationException();
                    
                    
                    },
                    
                    OnForbidden = async context =>
                    {
                    
                    
                    
                        throw new UnAuthorizationException();
                    
                    
                    }
                    


                };



            });
        }

        return services;

    }

    
}