using Common.CQRS;

namespace ClassDomain.Model.Parent.Command;

public class UpdateParentPasswordCommand:ICommand
{
    
    public Guid Id { get; set; }
    
    public string Password { get; set; }
    
    
}