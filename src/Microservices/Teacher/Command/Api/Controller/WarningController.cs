using Common.Api;
using Common.Attributes;
using Common.Enum;
using Domain.AppMetaData;
using Domain.Model.Teacher.Command;
using Domain.Model.Warning.Command;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class WarningController:ApiController
{
    
    [HttpPost(WarningRouter.prefix)]
    
    [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> AddWarning([FromBody] AddWarningCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }

    
    [HttpDelete(WarningRouter.prefix)]
    
    [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> DeleteWarning([FromBody] DeleteWarningCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }

    
}