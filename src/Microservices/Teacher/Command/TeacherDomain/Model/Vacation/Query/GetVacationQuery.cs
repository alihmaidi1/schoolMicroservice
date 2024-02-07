using Common.CQRS;

namespace Domain.Model.Vacation.Query;

public class GetVacationQuery:IQuery
{
 
    
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }

    
    
}