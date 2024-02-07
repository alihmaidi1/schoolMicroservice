using Common.CQRS;

namespace Domain.Model.Vacation.Command;

public class DeleteVacationCommand:ICommand
{
    
    public Guid Id { get; set; }
    
}