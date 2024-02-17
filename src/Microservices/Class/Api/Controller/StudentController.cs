using ClassDomain.AppMetaData;
using ClassDomain.Model.Student.Command;
using ClassDomain.Model.Student.Query;
using ClassDomain.Model.Year.Command;
using Common.Api;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class StudentController:ApiController
{
    
    
    [HttpPost(StudentRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }

    
    [HttpDelete(StudentRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> DeleteStudent([FromQuery] DeleteStudentCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    
    [HttpPut(StudentRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    
    
    [HttpGet(StudentRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> GetAllStudent([FromQuery]GetAllStudentQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
}