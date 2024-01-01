using System.Security.Claims;
using Infrutructure.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Infrutructure.Authorization.Handlers;

public class PermissionAuthorizationHandler:AuthorizationHandler<PermissionRequirement>
{
    public ApplicationDbContext DBContext ;

    private IHttpContextAccessor _httpContextAccessor;
    public PermissionAuthorizationHandler(IHttpContextAccessor _httpContextAccessor, ApplicationDbContext DBContext)
    {

        this._httpContextAccessor = _httpContextAccessor;
        this.DBContext  = DBContext;

    }
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        
        if (context.User == null||context.User.Identity.IsAuthenticated==false)
        {
            return;
        }

        var Id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value;

        List<string>? permissions = DBContext.Admins.Where(x=>x.Id==new Guid(Id)).Select(x => x.Role.Permissions).SingleOrDefault();
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