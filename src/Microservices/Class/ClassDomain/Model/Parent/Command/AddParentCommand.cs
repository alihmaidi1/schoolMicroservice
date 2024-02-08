using Common.CQRS;

namespace ClassDomain.Model.Parent.Command;

public class AddParentCommand:ICommand
{
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }

    
    
}