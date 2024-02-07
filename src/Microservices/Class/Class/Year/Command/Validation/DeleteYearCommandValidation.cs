using Class.Repository.Year;
using ClassDomain.Model.Year.Command;
using FluentValidation;

namespace Class.Year.Command.Validation;

public class DeleteYearCommandValidation:AbstractValidator<DeleteYearCommand>
{

    public DeleteYearCommandValidation(IYearRepository yearRepository)
    {
     
        RuleFor(x => x.Id)

            .NotEmpty()
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(x=>yearRepository.IsExists(x))
            .WithMessage("this year is not exists in our data");

        
    }
    
}