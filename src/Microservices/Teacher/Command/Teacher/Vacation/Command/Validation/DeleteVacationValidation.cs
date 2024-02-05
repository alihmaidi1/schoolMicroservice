using Domain.Model.Vacation.Command;
using Domain.Repository.Vacation;
using FluentValidation;

namespace Teacher.Vacation.Command.Validation;

public class DeleteVacationValidation:AbstractValidator<DeleteVacationCommand>
{

    public DeleteVacationValidation(IVacationRepository vacationRepository)
    {
        RuleFor(x=>x.Id)
            .NotEmpty()
            .WithMessage("vacation id should be not empty")
            .NotNull()
            .WithMessage("vacation id should be not null")
            .Must(id=>vacationRepository.IsExists(id))
            .WithMessage("vacation  should be exists in our data");

    }
    
}