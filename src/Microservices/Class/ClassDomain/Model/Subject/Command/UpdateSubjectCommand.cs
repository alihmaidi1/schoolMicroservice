using Common.CQRS;

namespace ClassDomain.Model.Subject.Command;

public class UpdateSubjectCommand:ICommand
{
    public Guid Id { get; set; }

    
    public string Name { get; set; }
}