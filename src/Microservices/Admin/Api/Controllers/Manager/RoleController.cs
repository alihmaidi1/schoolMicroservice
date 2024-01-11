using Common.Api;
using Common.Attributes;
using Common.Enum;
using Domain.AppMetaData.Manager;
using Domain.Enum;
using Dto.Manager.Role;
using Microsoft.AspNetCore.Mvc;
using Model.Manager.Role.Command;
using Model.Manager.Role.Query;

namespace Api.Controllers.Manager;


// [AppAuthorize(Roles = nameof(RoleEnum.SuperAdmin))]
public class RoleController:ApiController
{
    
    
    [HttpGet(RoleRouter.Permission)]
    public async Task<IActionResult> Permission()
    {
        var response=await this.Mediator.Send(new GetPermissionsQuery());
        return response;
    }
    
    [HttpPost(RoleRouter.prefix)]
    public async Task<IActionResult> AddRole([FromBody]AddRoleCommand request)
    {
        var response=await this.Mediator.Send(request);
        return response;
    }
    
    
    
    [HttpPut(RoleRouter.prefix)]
    public async Task<IActionResult> UpdateRole([FromBody]UpdateRoleCommand request)
    {
        var response=await this.Mediator.Send(request);
        return response;
    }
    
    
    
    [HttpDelete(RoleRouter.prefix)]
    public async Task<IActionResult> DeleteRole([FromBody]DeleteRoleCommand request)
    {
     
        var response=await this.Mediator.Send(request);
        return response;
    }

    
    
    [HttpGet(RoleRouter.prefix)]
    public async Task<IActionResult> GetAllRole([FromQuery]GetRolesQuery request)
    {
     
        var response=await this.Mediator.Send(request);
        return response;
    }
    
    
    [HttpGet(RoleRouter.Admin)]
    public async Task<IActionResult> GetAllRole([FromQuery]GetManagerByRoleQuery request)
    {
        var response=await this.Mediator.Send(request);
        return response;
    }
}