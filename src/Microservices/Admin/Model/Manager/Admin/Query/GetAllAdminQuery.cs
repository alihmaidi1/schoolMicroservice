using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Admin.Query;

public class GetAllAdminQuery:IRequest<JsonResult>
{
    
    public string? OrderBy { get; set; }
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }
}