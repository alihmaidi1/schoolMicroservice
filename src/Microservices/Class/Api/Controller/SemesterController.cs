using ClassDomain.AppMetaData;
using ClassDomain.Model.Semester.Command;
using Common.Api;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;


public class SemesterController:ApiController
{
    
    [HttpPost(SemesterRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> Addsemester([FromBody] AddSemesterCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }

    
    
    [HttpDelete(SemesterRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> Deletesemester([FromQuery] DeleteSemesterCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
}