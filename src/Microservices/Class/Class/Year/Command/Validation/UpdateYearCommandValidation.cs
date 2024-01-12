using Class.Repository.Year;
using ClassDomain.Model.Year.Command;
using FluentValidation;

namespace Class.Year.Command.Validation;

public class UpdateYearCommandValidation:AbstractValidator<UpdateYearCommand>
{


    public UpdateYearCommandValidation(IYearRepository yearRepository)
    {
        
        
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(x=>!yearRepository.IsExists(x.Name,x.Id))
            .WithMessage("this year is already exists in our data");

        RuleFor(x => x.Id)

            .NotEmpty()
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(x=>yearRepository.IsExists(x))
            .WithMessage("this year is not exists in our data");


    }
    
}