using FluentValidation;
using Model.Manager.Admin.Command;
using Repository.Manager.Admin;
using Repository.Manager.Role;

namespace Admin.Manager.Admin.Command.Validation;

public class UpdateAdminValidation:AbstractValidator<UpdateAdminCommand>
{

    
    
    public UpdateAdminValidation(IRoleRepository roleRepository,IAdminRepository adminRepository)
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

        
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("email should be not empty")
            .NotNull()
            .WithMessage("email should be not null")
            .Must(x => !adminRepository.IsEmailExists(x.Email,x.AdminId))
            .WithMessage("email address is already exists");

        RuleFor(x => x.AdminId)
            .NotEmpty()
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(x=>adminRepository.IsExists(x))
            .WithMessage("this admin is not exists in our data");
        

    }
    
    
}