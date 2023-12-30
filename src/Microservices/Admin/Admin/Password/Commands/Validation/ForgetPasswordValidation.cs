using FluentValidation;
using Model.Password;
using Repository.Manager.Admin;

namespace Admin.Password.Commands.Validation;

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
            .WithMessage("email should be email address");

    }

    
}