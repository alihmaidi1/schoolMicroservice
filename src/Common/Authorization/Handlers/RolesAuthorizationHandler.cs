using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace Common.Authorization.Handlers;

public class RolesAuthorizationHandler:AuthorizationHandler<RolesAuthorizationRequirement>
{
    
    private IHttpContextAccessor _httpContextAccessor;

    public RolesAuthorizationHandler(IHttpContextAccessor _httpContextAccessor)
    {

        this._httpContextAccessor = _httpContextAccessor;

    }
    
    
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
    {
        if (context.User==null||context.User?.Identity?.IsAuthenticated==false)
        {
            context.Fail();
        }
        var Roles = requirement.AllowedRoles;
        
        var role = _httpContextAccessor.HttpContext.User.Claims.Any(x => x.Type.Equals("role")&&Roles.Any(role=>role.Equals(x)));
        
        if (role)
        {
            context.Succeed(requirement);
        }
        else
        {
            
            context.Fail();
        }

        context.Succeed(requirement);

    }
}