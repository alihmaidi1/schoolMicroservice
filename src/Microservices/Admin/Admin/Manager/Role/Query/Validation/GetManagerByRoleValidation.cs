using Common.ExtensionMethod;
using FluentValidation;
using Model.Manager.Role.Command;
using Model.Manager.Role.Query;
using Repository.Manager.Admin.Operation;
using Repository.Manager.Role;
using Repository.Manager.Role.Operation;

namespace Admin.Manager.Role.Query.Validation;

public class GetManagerByRoleValidation:AbstractValidator<GetManagerByRoleQuery>
{

    public GetManagerByRoleValidation(IRoleRepository roleRepository)
    {
     
        
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(Id=>roleRepository.IsExists(Id))
            .WithMessage("id is not exists in our data");

        
        
        RuleFor(x => x.OrderBy)
            .Must(x => CrudOpterationRule.IsValidOrder(x, AdminSorting.OrderBy))
            .WithMessage("order by string is not valid");
        
        
    }
    
}