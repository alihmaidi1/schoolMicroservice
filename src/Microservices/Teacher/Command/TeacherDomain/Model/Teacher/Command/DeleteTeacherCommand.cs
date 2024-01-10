using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Model.Teacher.Command;

public class DeleteTeacherCommand:IRequest<JsonResult>
{
    
    public Guid Id { get; set; }
    
}