using Class.Repository.ClassYear;
using ClassDomain.Model.Bill.Command;
using FluentValidation;

namespace Class.Bill.Command.Validation;

public class AddBillToClassYearValidation:AbstractValidator<AddBillToClassYearCommand>
{


    public AddBillToClassYearValidation(IClassYearRepository classYearRepository)
    {
        
        RuleFor(x => x.ClassYearId)
            .NotEmpty()
            .WithMessage("year id should be not empty")
            .NotNull()
            .WithMessage("year id should be not null")
            .Must(ID=>classYearRepository.IsExists(ID))
            .WithMessage("this year is not exists");

        RuleFor(x => x.Money)
            .NotEmpty()
            .WithMessage("money should be not empty")
            .NotNull()
            .WithMessage("money  should be not null")
            .Must(x=>x>0)
            .WithMessage("money should be valid value");
        
        
        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage("Date  should be not empty")
            .NotNull()
            .WithMessage("Date  should be not null")
            .Must(x=>x>DateTime.Now)
            .WithMessage("Date should be valid value");
        
    }
    
}