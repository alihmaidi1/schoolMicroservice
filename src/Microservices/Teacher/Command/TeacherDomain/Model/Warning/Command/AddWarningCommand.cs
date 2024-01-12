using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Model.Warning.Command;

public class AddWarningCommand:IRequest<JsonResult>
{
    
    public string Reson { get; set; }
    
    public Guid TeacherID { get; set; }
    
    
}