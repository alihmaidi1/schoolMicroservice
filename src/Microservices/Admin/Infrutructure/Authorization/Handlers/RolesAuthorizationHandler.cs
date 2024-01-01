using System.Security.Claims;
using Domain.Entities.Manager.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace Infrutructure.Authorization.Handlers;

public class RolesAuthorizationHandler:AuthorizationHandler<RolesAuthorizationRequirement>
{
    
    public ApplicationDbContext DBContext;

    private IHttpContextAccessor _httpContextAccessor;
    
    
    public RolesAuthorizationHandler(IHttpContextAccessor _httpContextAccessor,ApplicationDbContext DBContext)
    {

        this._httpContextAccessor = _httpContextAccessor;
        this.DBContext = DBContext; 
    }
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
    {

        
        if (context.User==null||context.User?.Identity?.IsAuthenticated==false)
        {
             context.Fail();
            

        }
        
        var Roles = requirement.AllowedRoles;
        var Id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value;

        var roleName = DBContext.Admins.Where(x=>x.Id==new Guid(Id)).Select(x => x.Role.Name).SingleOrDefault();
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