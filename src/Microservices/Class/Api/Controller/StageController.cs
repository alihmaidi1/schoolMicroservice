using ClassDomain.AppMetaData;
using ClassDomain.Model.Stage.Query;
using Common.Api;
using Common.Attributes;
using Common.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class StageController:ApiController
{
    
    
 
    [HttpGet(StageRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> GetAllStage([FromQuery] GetAllStageQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }

    [HttpGet(StageRouter.GetById)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> GetStage([FromQuery] GetStageQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
}