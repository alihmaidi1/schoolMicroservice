using Common.ExtensionMethod;
using FluentValidation;
using Model.Manager.Role.Query;
using Repository.Manager.Role.Operation;

namespace Admin.Manager.Role.Query.Validation;

public class GetRolesValidation:AbstractValidator<GetRolesQuery>
{

    public GetRolesValidation()
    {
        
        
        RuleFor(x => x.OrderBy)
            .Must(x => CrudOpterationRule.IsValidOrder(x, RoleSorting.OrderBy))
            .WithMessage("order by string is not valid");
        
    }
    
}