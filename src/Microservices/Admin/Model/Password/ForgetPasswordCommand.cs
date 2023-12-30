using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Password;

public class ForgetPasswordCommand:IRequest<JsonResult>
{
    
    
    public string Email { get; set; }

}