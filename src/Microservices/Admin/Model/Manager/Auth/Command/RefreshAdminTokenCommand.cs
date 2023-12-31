using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Auth.Command;

public class RefreshAdminTokenCommand:IRequest<JsonResult>
{
    
    
    public string RefreshToken { get; set; }

}