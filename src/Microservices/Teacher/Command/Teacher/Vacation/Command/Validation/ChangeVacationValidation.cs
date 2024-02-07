using Domain.Model.Vacation.Command;
using Domain.Repository.Vacation;
using FluentValidation;

namespace Teacher.Vacation.Command.Validation;

public class ChangeVacationValidation:AbstractValidator<ChangeVacationCommand>
{

    public ChangeVacationValidation(IVacationRepository vacationRepository)
    {

        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("status should be not empty")
            .NotNull()
            .WithMessage("status should be not null");
        
        
        RuleFor(x=>x.Id)
            .NotEmpty()
            .WithMessage("vacation id should be not empty")
            .NotNull()
            .WithMessage("vacation id should be not null")
            .Must(id=>vacationRepository.IsExists(id))
            .WithMessage("vacation  should be exists in our data");

        
        

    }
 
    
}