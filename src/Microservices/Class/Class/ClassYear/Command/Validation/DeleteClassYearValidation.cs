using Class.Repository.ClassYear;
using ClassDomain.Model.ClassYear.Command;
using FluentValidation;

namespace Class.ClassYear.Command.Validation;

public class DeleteClassYearValidation:AbstractValidator<DeleteClassYearCommand>
{

    public DeleteClassYearValidation(IClassYearRepository classYearRepository)
    {
        
        
        RuleFor(x=>x.Id)
            
            .NotEmpty()
            .WithMessage("year id should be not empty")
            .NotNull()
            .WithMessage("year id should be not null")
            .Must(Id=>classYearRepository.IsExists(Id))
            .WithMessage("this year is not exists");

        
    }
    
}