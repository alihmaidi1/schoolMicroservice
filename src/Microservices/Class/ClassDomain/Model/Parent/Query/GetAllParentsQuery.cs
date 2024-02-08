using Common.CQRS;

namespace ClassDomain.Model.Parent.Query;

public class GetAllParentsQuery:IQuery
{
    
    public string? OrderBy { get; set; }
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }
    
}