using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Model.Teacher.Command;

public class AddTeacherCommand:IRequest<JsonResult>
{
    public string Name { get; set; }
    
    public string Email { get; set; }

    public string Password { get; set; }
    
    public bool Status { get; set; }

}