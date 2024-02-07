using FluentValidation;
using Model.Manager.Password.Command;
using Repository.Manager.Admin;

namespace Admin.Manager.Password.Commands.Validation;

public class CheckCodeValidation:AbstractValidator<CheckCodeCommand>
{
    
    public CheckCodeValidation(IAdminRepository adminRepository)
    {

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("code should be not empty")
            .NotNull()
            .WithMessage("code should be not null")
            .Length(6)
            .WithMessage("code should be 6 charectar")
            .Must(x => adminRepository.CheckCode(x))
            .WithMessage("code is not valid");
    }

    
}