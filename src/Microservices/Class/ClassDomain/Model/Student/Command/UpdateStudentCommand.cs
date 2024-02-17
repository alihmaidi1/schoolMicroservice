using Common.CQRS;

namespace ClassDomain.Model.Student.Command;

public class UpdateStudentCommand:ICommand
{
    
    public Guid Id { get; set; }
    
    
    public bool Gender { get; set; }
    public string Email { get; set; }
    
    public int Number { get; set; }

    public string Name { get; set; }
    
    public Guid ParentId { get; set; }
    
    
}