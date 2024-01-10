using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Model.Teacher.Command;

public class ChangeTeacherStatusCommand:IRequest<JsonResult>
{
    
    
    public Guid Id { get; set; }
    
    public bool Status { get; set; }
    
}