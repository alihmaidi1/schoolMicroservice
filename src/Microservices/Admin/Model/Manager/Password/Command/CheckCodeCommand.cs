using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Password.Command;

public class CheckCodeCommand:IRequest<JsonResult>
{
    
    
    public string Code { get; set; }

}