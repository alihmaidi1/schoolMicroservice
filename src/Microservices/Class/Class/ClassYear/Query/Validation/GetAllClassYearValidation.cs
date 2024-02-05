using Class.Repository.Class;
using ClassDomain.Model.ClassYear.Query;
using FluentValidation;

namespace Class.ClassYear.Query.Validation;

public class GetAllClassYearValidation:AbstractValidator<GetAllClassYearQuery>
{

    public GetAllClassYearValidation(IClassRepository classRepository)
    {
        RuleFor(x => x.ClassId)
            .NotEmpty()
            .WithMessage("Class id should be not empty")
            .NotNull()
            .WithMessage("Class id should be not null")
            .Must(ID=>classRepository.IsExists(ID))
            .WithMessage("This Class is not exists");


        
    }
    
}