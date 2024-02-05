using Common.CQRS;

namespace Domain.Model.Vacation.Command;

public class CancelVacationCommand:ICommand
{
    
    public Guid Id { get; set; }
    
}