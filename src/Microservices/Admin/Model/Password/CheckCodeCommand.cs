using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Password;

public class CheckCodeCommand:IRequest<JsonResult>
{
    
    
    public string Code { get; set; }

}