using Common.Api;
using Domain.AppMetaData;
using Domain.Model.Vacation.Command;
using Domain.Model.Vacation.Query;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class VacationController:ApiController
{
    
    
    [HttpPost(VacationRouter.prefix)]
    
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> AddWarning([FromBody] AddVacationCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }
    
    [HttpPatch(VacationRouter.prefix)]
    
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> ChangeVacationStastus([FromBody] ChangeVacationCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }
    
    
    [HttpDelete(VacationRouter.prefix)]
    
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> DeleteVacation([FromBody] DeleteVacationCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }
    
    
    [HttpDelete(VacationRouter.Cancel)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> CancelVacation([FromBody] CancelVacationCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }

    
    [HttpGet(VacationRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> GetVacation([FromQuery]GetVacationQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }

    
}