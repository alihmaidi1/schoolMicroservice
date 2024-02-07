using Common.CQRS;

namespace ClassDomain.Model.Subject.Command;

public class AddSubjectCommand:ICommand
{
    
    public string Name { get; set; }
    
}