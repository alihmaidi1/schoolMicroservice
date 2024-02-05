using Common.CQRS;

namespace Domain.Model.Warning.Query;

public class GetWarningQuery:IQuery
{
    
        
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }

    
}