using Common.CQRS;

namespace ClassDomain.Model.Student.Query;

public class GetAllStudentQuery:IQuery
{
    
    
    public string? OrderBy { get; set; }
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }
    
    public string? Name { get; set; }
    
    public string? ParentName { get; set; }
    
}
