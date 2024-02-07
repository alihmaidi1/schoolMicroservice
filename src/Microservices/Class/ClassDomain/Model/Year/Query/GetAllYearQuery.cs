using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.Year.Query;

public class GetAllYearQuery:IQuery
{
    
    public string? OrderBy { get; set; }
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }

    
}