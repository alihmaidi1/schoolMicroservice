using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Role.Query;

public class GetRolesQuery:IRequest<JsonResult>
{
    
    
    public string? OrderBy { get; set; }
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }

    
}