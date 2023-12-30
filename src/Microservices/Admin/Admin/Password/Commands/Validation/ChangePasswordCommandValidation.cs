using System.Data;
using FluentValidation;
using Model.Password;

namespace Admin.Password.Commands.Validation;

public class ChangePasswordCommandValidation:AbstractValidator<ChangePasswordCommand>
{

    public ChangePasswordCommandValidation()
    {

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("password should be not empty")
            .NotNull()
            .WithMessage("password should be not null")
            .MinimumLength(8)
            .WithMessage("password should be at leat 8 charecter");


    }
    
    
}