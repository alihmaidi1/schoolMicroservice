using Common.Api;
using Domain.Attributes;
using Microsoft.AspNetCore.Mvc;
using Model.Auth.Command;

namespace Api.Controllers;

public class AuthController:ApiController
{
    
    [HttpPost(AuthAdminRouter.Login)]
    
    public async Task<IActionResult> LoginAdmin([FromBody] LoginAdminCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

    [AppAuthorize]
    [HttpPost(AuthAdminRouter.Logout)]
    public async Task<IActionResult> LogoutAdmin()
    {
        var response = await this.Mediator.Send(new LogoutAdminCommand());
        return response;
    }
    
    
    
    [HttpPost(AuthAdminRouter.RefreshToken)]
    public async Task<IActionResult> RefreshTheToken( [FromBody]RefreshAdminTokenCommand command)
    {

        var response =await this.Mediator.Send(command);
        return response;


    }

    
}