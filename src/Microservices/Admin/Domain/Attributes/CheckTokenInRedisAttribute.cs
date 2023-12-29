using Common.Exceptions;
using Common.Redis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

using Microsoft.Extensions.DependencyInjection;
namespace Domain.Attributes;

public class CheckTokenInRedisAttribute:AuthorizeAttribute,IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        ICacheRepository CacheRepository = context.HttpContext.RequestServices.GetRequiredService<ICacheRepository>();
        var Token = context.HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];
        if (Token is not null && CacheRepository.IsExists("Token:" + Token))
        {
            return;
        }
        throw new UnAuthenticationException();

    }
}