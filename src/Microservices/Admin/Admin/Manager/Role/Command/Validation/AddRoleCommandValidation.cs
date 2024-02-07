using Domain.Enum;
using FluentValidation;
using Model.Manager.Role.Command;
using Repository.Manager.Role;

namespace Admin.Manager.Role.Command.Validation;

public class AddRoleCommandValidation:AbstractValidator<AddRoleCommand>
{

    public AddRoleCommandValidation(IRoleRepository roleRepository)
    {


        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("name should be not empty")
            .NotNull()
            .WithMessage("name should be not null")
            .Must(name=>!roleRepository.IsExists(name))
            .WithMessage("this role is already exists");

        
        
        RuleForEach(x => x.Permissions)
            .NotEmpty()
            .WithMessage("permission should be not empty")
            .NotNull()
            .WithMessage("permission should be not null")
            .Must(x=>Enum.GetNames(typeof(PermissionEnum)).Any(permission=>permission.Equals(x)))
            .WithMessage("this permission is not exists");


    }
    
}