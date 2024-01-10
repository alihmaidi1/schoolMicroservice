using Common.Api;
using Common.Attributes;
using Domain.AppMetaData.Manager;
using Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Manager.Admin.Command;
using Model.Manager.Admin.Query;
using Model.Manager.Auth.Command;

namespace Api.Controllers.Manager;


// [AppAuthorize(Roles = nameof(RoleEnum.SuperAdmin))]
[AppAuthorize]
public class AdminController:ApiController
{
    
    
    
    [HttpPost(AdminRouter.prefix)]
    public async Task<IActionResult> AddAdmin([FromBody] AddAdminCommand command,CancellationToken Token)
    {
        
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

    [HttpPut(AdminRouter.prefix)]
    public async Task<IActionResult> UpdateAdmin([FromBody] UpdateAdminCommand command,CancellationToken Token)
    {
        
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

    
    
    [HttpDelete(AdminRouter.prefix)]
    public async Task<IActionResult> DeleteAdmin([FromBody] DeleteAdminCommand command,CancellationToken Token)
    {
        
        var response = await this.Mediator.Send(command,Token);
        return response;

    }
    
    
    
    
    
    [HttpGet(AdminRouter.prefix)]
    public async Task<IActionResult> GetAllAdmin([FromQuery] GetAllAdminQuery command,CancellationToken Token)
    {
        
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

}