using Class.Repository.ClassYear;
using ClassDomain.Model.ClassYear.Command;
using FluentValidation;

namespace Class.ClassYear.Command.Validation;

public class UpdateClassYearValidation:AbstractValidator<UpdateClassYearCommand>
{

    public UpdateClassYearValidation(IClassYearRepository classYearRepository)
    {
        
        RuleFor(x=>x.Id)
            
            .NotEmpty()
            .WithMessage("year id should be not empty")
            .NotNull()
            .WithMessage("year id should be not null")
            .Must(Id=>classYearRepository.IsExists(Id))
            .WithMessage("this year is not exists");

        RuleForEach(x => x.Billings)
            .NotEmpty()
            .WithMessage("Billing  should be not empty")
            .NotNull()
            .WithMessage("Billing should be not null")
            .Must(x =>  x.Money > 0)
            .WithMessage("money should be and greator from zero")
            .Must(x=>x.Money !=null)
            .WithMessage("money should be not null")
            .Must(x => x.Date is DateTime &&x.Date!=null)
            .WithMessage("date should be date")
            .Must(x=>x.Date> DateTime.Now)
            .WithMessage("date should be valid");

    }
    
}