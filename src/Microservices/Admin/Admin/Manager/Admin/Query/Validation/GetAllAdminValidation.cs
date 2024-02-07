using Common.ExtensionMethod;
using FluentValidation;
using Model.Manager.Admin.Query;
using Repository.Manager.Admin.Operation;
using Repository.Manager.Role.Operation;

namespace Admin.Manager.Admin.Query.Validation;

public class GetAllAdminValidation:AbstractValidator<GetAllAdminQuery>
{

    
    public GetAllAdminValidation()
    {
        RuleFor(x => x.OrderBy)
            .Must(x => CrudOpterationRule.IsValidOrder(x, AdminSorting.OrderBy))
            .WithMessage("order by string is not valid");

    }
    
}