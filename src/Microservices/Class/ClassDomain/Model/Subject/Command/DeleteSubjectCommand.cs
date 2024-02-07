using Common.CQRS;

namespace ClassDomain.Model.Subject.Command;

public class DeleteSubjectCommand:ICommand
{
    
    public Guid Id { get; set; }
    
}