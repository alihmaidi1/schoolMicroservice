using Common.CQRS;

namespace Domain.Model.Vacation.Command;

public class AddVacationCommand:ICommand
{
    
    public string Reason { get; set; }
    
    public Guid TeacherId { get; set; }
    
    public Guid YearId { get; set; }
    
}