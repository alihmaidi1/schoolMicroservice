using Class.Repository.Parent;
using Class.Repository.Year;
using ClassDomain.Model.Parent.Query;
using Common.ExtensionMethod;
using FluentValidation;

namespace Class.Parent.Query.Validation;

public class GetAllParentValidation:AbstractValidator<GetAllParentsQuery>
{

    public GetAllParentValidation()
    {
        

        RuleFor(x => x.OrderBy)
            .Must(x => CrudOpterationRule.IsValidOrder(x, ParentSorting.OrderBy))
          .WithMessage("order by string is not valid");

        
    }
    
}