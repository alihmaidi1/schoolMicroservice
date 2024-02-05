using Class.Repository.Class;
using Class.Repository.Year;
using ClassDomain.Model.ClassYear.Command;
using FluentValidation;

namespace Class.ClassYear.Command.Validation;

public class AddClassYearValidation:AbstractValidator<AddClassYearCommand>
{

    public AddClassYearValidation(IYearRepository yearRepository,IClassRepository classRepository)
    {

        RuleFor(x => x.YearID)
            .NotEmpty()
            .WithMessage("year id should be not empty")
            .NotNull()
            .WithMessage("year id should be not null")
            .Must(ID=>yearRepository.IsExists(ID))
            .WithMessage("this year is not exists");
        
        RuleFor(x => x.ClassID)
            .NotEmpty()
            .WithMessage("Class id should be not empty")
            .NotNull()
            .WithMessage("Class id should be not null")
            .Must(ID=>classRepository.IsExists(ID))
            .WithMessage("This Class is not exists");


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