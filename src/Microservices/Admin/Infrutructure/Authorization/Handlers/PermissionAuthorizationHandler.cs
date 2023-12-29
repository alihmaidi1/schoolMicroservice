using Infrutructure.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace Infrutructure.Authorization.Handlers;

public class PermissionAuthorizationHandler:AuthorizationHandler<PermissionRequirement>
{
    public ApplicationDbContext DBContext ;

    
    public PermissionAuthorizationHandler( ApplicationDbContext DBContext) {
            
        this.DBContext  = DBContext;

    }
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        
        if (context.User == null||context.User.Identity.IsAuthenticated==false)
        {
            return;
        }

        List<string>? permissions = DBContext.Admins.Select(x => x.Role.Permissions).SingleOrDefault();
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