using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Infrutructure.Authorization.Handlers;

public class RolesAuthorizationHandler:AuthorizationHandler<RolesAuthorizationRequirement>
{
    
    public ApplicationDbContext DBContext;

    public RolesAuthorizationHandler(ApplicationDbContext DBContext) { 
        
        this.DBContext = DBContext; 
    }
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
    {

        
        if (context.User==null||context.User?.Identity?.IsAuthenticated==false)
        {
             context.Fail();
            

        }
        
        var Roles = requirement.AllowedRoles;

        var roleName = DBContext.Admins.Select(x => x.Role.Name).SingleOrDefault();
        if (Roles.Any(x => x.Equals(roleName)))
        {
            
            context.Succeed(requirement);
        }
        else
        {
            
            context.Fail();
        }



    }
}