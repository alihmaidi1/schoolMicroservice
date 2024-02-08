using ClassDomain.AppMetaData;
using ClassDomain.Model.ClassYear.Command;
using ClassDomain.Model.ClassYear.Query;
using Common.Api;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class ClassYearController:ApiController
{
    
    
    [HttpPost(ClassYearRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> AddClassYear([FromBody] AddClassYearCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }

    
    // [HttpPut(ClassYearRouter.prefix)]
    // // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    // public async Task<IActionResult> UpdateClassYear([FromBody] UpdateClassYearCommand command,CancellationToken Token)
    // {
    //     var response = await this.Mediator.Send(command,Token);
    //     return response;
    // }
    
    
    [HttpGet(ClassYearRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> GetAllClassYear([FromQuery] GetAllClassYearQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    
    [HttpGet(ClassYearRouter.get)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> GetClassYear([FromQuery] GetClassYearQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    
    [HttpDelete(ClassYearRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> DeleteClassYear([FromQuery] DeleteClassYearCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
}