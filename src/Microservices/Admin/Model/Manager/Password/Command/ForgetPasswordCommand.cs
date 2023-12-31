using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Password.Command;

public class ForgetPasswordCommand:IRequest<JsonResult>
{
    
    
    public string Email { get; set; }

}