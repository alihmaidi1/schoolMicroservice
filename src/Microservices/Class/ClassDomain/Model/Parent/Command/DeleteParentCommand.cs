using Common.CQRS;

namespace ClassDomain.Model.Parent.Command;

public class DeleteParentCommand:ICommand
{
    
    public Guid Id { get; set; }
    
    
    
}