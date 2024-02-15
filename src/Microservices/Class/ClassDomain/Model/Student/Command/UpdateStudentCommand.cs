using Common.CQRS;

namespace ClassDomain.Model.Student.Command;

public class UpdateStudentCommand:ICommand
{
    
    public Guid Id { get; set; }
    
    
    public string Email { get; set; }
    
    
    public string Name { get; set; }
    
    public Guid ParentId { get; set; }
    
    
}