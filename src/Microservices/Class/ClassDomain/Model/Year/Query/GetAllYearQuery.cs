using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.Year.Query;

public class GetAllYearQuery:IRequest<JsonResult>
{
    
    public string? OrderBy { get; set; }
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }

    
}