using Common.CQRS;

namespace ClassDomain.Model.Semester.Command;

public class DeleteSemesterCommand:ICommand
{
    
    
    public Guid Id { get; set; }
    
}