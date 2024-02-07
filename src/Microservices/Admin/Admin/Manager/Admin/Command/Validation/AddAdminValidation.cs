using FluentValidation;
using Model.Manager.Admin.Command;
using Repository.Manager.Admin;
using Repository.Manager.Role;

namespace Admin.Manager.Admin.Command.Validation;

public class AddAdminValidation:AbstractValidator<AddAdminCommand>
{

    public AddAdminValidation(IAdminRepository adminRepository,IRoleRepository roleRepository)
    {

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("name should be not empty")
            .NotNull()
            .WithMessage("name should be not null");

        
        RuleFor(x=>x.RoleId)
            .NotEmpty()
            .WithMessage("name should be not empty")
            .NotNull()
            .WithMessage("name should be not null")
            .Must(Id=>roleRepository.IsExists(Id))
            .WithMessage("this role is not valid");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("password should be not empty")
            .NotNull()
            .WithMessage("password should be not null")
            .MinimumLength(8)
            .WithMessage("password should be at leat 8 charecter");

        
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("email should be not empty")
            .NotNull()
            .WithMessage("email should be not null")
            .Must(x => !adminRepository.IsEmailExists(x))
            .WithMessage("email address is already exists");
        
        

    }
    
}