using FluentValidation;
using Model.Manager.Auth.Command;
using Repository.Manager.Admin;

namespace Admin.Manager.Auth.Command.Validation;

public class LoginAdminValidation:AbstractValidator<LoginAdminCommand>

{
    public LoginAdminValidation(IAdminRepository AdminRepository)
    {

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email cannot be empty")
            .NotNull()
            .WithMessage("Email cannot be null")
            .EmailAddress()
            .WithMessage("this column should be email address")
            .Must(email=>AdminRepository.IsEmailExists(email))
            .WithMessage("email is not found in our data");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("this column should be not null")
            .NotNull()
            .WithMessage("this column should be not null")
            .MinimumLength(8)
            .WithMessage("length of password should be greater from 8 charecter");




    }



}
