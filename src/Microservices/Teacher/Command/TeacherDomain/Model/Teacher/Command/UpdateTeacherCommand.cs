using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Model.Teacher.Command;

public class UpdateTeacherCommand:IRequest<JsonResult>
{

    public Guid Id { get; set; }
  
    public string Name { get; set; }
    
    public string Email { get; set; }

    public string Password { get; set; }
    
    public bool Status { get; set; }

    
}