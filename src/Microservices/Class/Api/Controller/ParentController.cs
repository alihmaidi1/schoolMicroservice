using ClassDomain.AppMetaData;
using ClassDomain.Model.Parent.Command;
using ClassDomain.Model.Parent.Query;
using ClassDomain.Model.Stage.Query;
using Common.Api;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class ParentController:ApiController
{
    
    [HttpGet(ParentRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> GetAllParent([FromQuery] GetAllParentsQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    
    [HttpGet(ParentRouter.get)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> GetParent([FromQuery] GetParentQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    [HttpPost(ParentRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> AddParent([FromBody] AddParentCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    
    [HttpPut(ParentRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> UpdateParent([FromBody] UpdateParentCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    
    [HttpPatch(ParentRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> UpdateParentPassword([FromBody] UpdateParentPasswordCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    
    [HttpDelete(ParentRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> DeleteParent([FromQuery] DeleteParentCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
}