using Common.CQRS;

namespace ClassDomain.Model.Parent.Query;

public class GetParentQuery : IQuery
{
    
    
    public Guid Id { get; set; }
    
}