using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Password;

public class ChangePasswordCommand:IRequest<JsonResult>
{
    
    
    public string Password { get; set; }
    
}