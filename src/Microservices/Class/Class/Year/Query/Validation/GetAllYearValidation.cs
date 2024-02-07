using Class.Repository.Stage;
using Class.Repository.Year;
using ClassDomain.Model.Year.Query;
using Common.ExtensionMethod;
using FluentValidation;

namespace Class.Year.Query.Validation;

public class GetAllYearValidation:AbstractValidator<GetAllYearQuery>
{

    public GetAllYearValidation()
    {
        
        
        RuleFor(x => x.OrderBy)
            .Must(x => CrudOpterationRule.IsValidOrder(x, YearSorting.OrderBy))
            .WithMessage("order by string is not valid");

        
    }
    
}