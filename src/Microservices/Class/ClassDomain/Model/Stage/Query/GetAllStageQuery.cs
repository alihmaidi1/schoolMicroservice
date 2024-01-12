using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.Stage.Query;

public class GetAllStageQuery:IRequest<JsonResult>
{
    public string? OrderBy { get; set; }
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }

    
}