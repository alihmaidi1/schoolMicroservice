using ClassDomain.AppMetaData;
using ClassDomain.Model.Stage.Query;
using ClassDomain.Model.Year.Command;
using ClassDomain.Model.Year.Query;
using Common.Api;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class YearController:ApiController
{
    
    [HttpPost(YearRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> AddYear([FromBody] AddYearCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }

    
    [HttpPut(YearRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> UpdateYear([FromBody] UpdateYearCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    
    [HttpDelete(YearRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> DeleteYear([FromBody] DeleteYearCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    
    [HttpGet(YearRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> DeleteYear([FromQuery] GetAllYearQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
}