using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.ClassYear.Query;

public class GetAllClassYearQuery:IQuery
{
    
    
    public Guid ClassId { get; set; }
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }

    
}