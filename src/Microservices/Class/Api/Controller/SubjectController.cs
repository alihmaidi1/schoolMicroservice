using ClassDomain.AppMetaData;
using ClassDomain.Model.Subject.Command;
using Common.Api;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class SubjectController:ApiController
{
    [HttpPost(SubjectRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> AddSubject([FromBody] AddSubjectCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }

    
    [HttpPut(SubjectRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> UpdateSubject([FromBody] UpdateSubjectCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    
    [HttpDelete(SubjectRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> AddSubject([FromBody] DeleteSubjectCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
}