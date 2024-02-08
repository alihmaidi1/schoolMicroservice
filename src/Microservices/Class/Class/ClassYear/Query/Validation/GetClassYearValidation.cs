using Class.Repository.ClassYear;
using ClassDomain.Model.ClassYear.Query;
using FluentValidation;

namespace Class.ClassYear.Query.Validation;

public class GetClassYearValidation:AbstractValidator<GetClassYearQuery>
{

    public GetClassYearValidation(IClassYearRepository classYearRepository)
    {


        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Class year id should be not empty")
            .NotNull()
            .WithMessage("Class year id should be not null")
            .Must(id=>classYearRepository.IsExists(id))
            .WithMessage("this class year is not correct");

    }
    
    
}