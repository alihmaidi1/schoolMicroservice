using Common.CQRS;

namespace Domain.Model.Teacher.Query;

public class GetTeacherQuery:IQuery
{
    
    public Guid Id { get; set; }
    
}