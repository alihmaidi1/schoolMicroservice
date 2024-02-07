using Common.CQRS;

namespace Domain.Model.Vacation.Command;

public class ChangeVacationCommand:ICommand
{
    
    
    public Guid Id { get; set; }
    
    public bool Status { get; set; }
    
    
}