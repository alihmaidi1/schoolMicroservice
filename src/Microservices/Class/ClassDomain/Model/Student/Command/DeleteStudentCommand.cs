using Common.CQRS;

namespace ClassDomain.Model.Student.Command;

public class DeleteStudentCommand:ICommand
{
    
    
    public Guid Id { get; set; }
    
    
}