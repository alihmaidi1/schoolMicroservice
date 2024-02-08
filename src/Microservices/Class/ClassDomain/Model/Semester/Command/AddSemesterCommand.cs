using Common.CQRS;

namespace ClassDomain.Model.Semester.Command;

public class AddSemesterCommand:ICommand
{
    
    
    public string Name { get; set; }
    
    public Guid ClassYearId { get; set; }
    
    
}