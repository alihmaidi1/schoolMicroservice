using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Model.Teacher.Query;

public class GetAllTeacher:IRequest<JsonResult>
{
 
    
    public string? OrderBy { get; set; }
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }
    
    
}