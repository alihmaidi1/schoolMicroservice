using FluentValidation;
using Model.Manager.Password.Command;
using Repository.Manager.Admin;

namespace Admin.Manager.Password.Commands.Validation;

public class ForgetPasswordValidation:AbstractValidator<ForgetPasswordCommand>
{
    public ForgetPasswordValidation(IAdminRepository AdminRepository)
    {


        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("email should be not empty")
            .NotNull()
            .WithMessage("email should be not null")
            .Must(x => AdminRepository.IsEmailExists(x))
            .WithMessage("email address is already exists");

    }

    
}