using Common.CQRS;

namespace ClassDomain.Model.Parent.Command;

public class UpdateParentCommand:ICommand
{

    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    

    
}