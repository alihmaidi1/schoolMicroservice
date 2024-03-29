using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Role.Query;

public class GetManagerByRoleQuery:IQuery
{

    
    public Guid Id { get; set; }
    
    
    public string? OrderBy { get; set; }
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }
    
}