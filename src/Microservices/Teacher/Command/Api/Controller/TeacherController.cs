using Common.Api;
using Common.Attributes;
using Common.Enum;
using Domain.AppMetaData;
using Domain.Model.Teacher;
using Domain.Model.Teacher.Command;
using Domain.Model.Teacher.Query;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class TeacherController:ApiController
{
    
    
    [HttpPost(TeacherRouter.prefix)]
    
    [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> AddTeacher([FromBody] AddTeacherCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }

    
    
    [HttpPut(TeacherRouter.prefix)]
    
    [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> UpdateTeacher([FromBody] UpdateTeacherCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }

    [HttpPatch(TeacherRouter.prefix)]
    
    [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> ChangeTeacherStatus([FromBody] ChangeTeacherStatusCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }
    
    
    
    [HttpDelete(TeacherRouter.prefix)]
    
    [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> DeleteTeacher([FromBody] DeleteTeacherCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }

    
        
    [HttpGet(TeacherRouter.prefix)]
    [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> GetAllTeacher([FromQuery] GetAllTeacher command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    
}