using Common.CQRS;

namespace ClassDomain.Model.ClassYear.Query;

public class GetClassYearQuery:IQuery
{
    
    public Guid Id { get; set; }
    
    
}