using Common.Api;
using Domain.Attributes;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Model.Password;

namespace Api.Controllers;

public class PasswordController:ApiController
{
    
    [HttpPost(PasswordRouter.ResetPassword)]
    public async Task<IActionResult> ForgetPassword([FromBody]ForgetPasswordCommand request)
    {
        
        var response=await this.Mediator.Send(request);
        return response;
    }

    [AppAuthorize(AuthenticationSchemes = "JwtResetAdmin")]

    [HttpPost(PasswordRouter.CheckCode)]
    public async Task<IActionResult> CheckCode([FromBody]CheckCodeCommand request)
    {
        
        var response=await this.Mediator.Send(request);
        return response;
    }
    
    
    
    [AppAuthorize]
    [HttpPost(PasswordRouter.ChangePassword)]
    public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordCommand request)
    {
        
        var response=await this.Mediator.Send(request);
        return response;
    }
}