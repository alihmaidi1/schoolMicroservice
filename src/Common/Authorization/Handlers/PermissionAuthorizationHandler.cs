using System.Security.Claims;
using Common.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Common.Authorization.Handlers;

public class PermissionAuthorizationHandler:AuthorizationHandler<PermissionRequirement>
{
    private IHttpContextAccessor _httpContextAccessor;


    public PermissionAuthorizationHandler(IHttpContextAccessor _httpContextAccessor)
    {

        this._httpContextAccessor = _httpContextAccessor;



    }
    
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (context.User == null||context.User.Identity.IsAuthenticated==false)
        {
            return;
        }
        
        List<string> permissions = _httpContextAccessor.HttpContext.User.Claims.Select(x=>x.Value).ToList();
        var RequiredPermission = requirement.Permission;
        
        if (permissions.Any(x => x.Equals(RequiredPermission)))
        {
            
            context.Succeed(requirement);
            
        }
        else
        {
            
            context.Fail();
        }



        
    }
}