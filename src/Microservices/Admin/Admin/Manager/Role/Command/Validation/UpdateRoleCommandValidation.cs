using Domain.Enum;
using FluentValidation;
using Model.Manager.Role.Command;
using Repository.Manager.Role;

namespace Admin.Manager.Role.Command.Validation;

public class UpdateRoleCommandValidation:AbstractValidator<UpdateRoleCommand>
{

    public UpdateRoleCommandValidation(IRoleRepository roleRepository)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(Id=>roleRepository.IsExists(Id))
            .WithMessage("id is not exists in our data");
        
        
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("name should be not empty")
            .NotNull()
            .WithMessage("name should be not null")
            .Must(request=>!roleRepository.IsExists(request.Name,request.Id))
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