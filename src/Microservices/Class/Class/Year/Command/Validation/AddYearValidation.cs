using Class.Repository.Year;
using ClassDomain.Model.Year.Command;
using FluentValidation;

namespace Class.Year.Command.Validation;

public class AddYearValidation:AbstractValidator<AddYearCommand>
{

    public AddYearValidation(IYearRepository yearRepository)
    {
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(x=>!yearRepository.IsExists(x))
            .WithMessage("this year is already exists in our data");

    }
    
}