using Common.Api;
using Domain.AppMetaData;
using Domain.Model.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class TeacherController:ApiController
{
    
    
    
    [HttpPost(TeacherRouter.prefix)]
    
    public async Task<IActionResult> AddTeacher([FromBody] AddTeacherCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }

}