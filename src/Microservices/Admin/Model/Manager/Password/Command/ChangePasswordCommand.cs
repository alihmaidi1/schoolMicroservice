using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Password.Command;

public class ChangePasswordCommand:IRequest<JsonResult>
{
    
    
    public string Password { get; set; }
    
}