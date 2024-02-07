using Domain.Model.Warning.Command;
using Domain.Repository.Warning;
using FluentValidation;

namespace Teacher.Warning.Command.Validation;

public class DeleteWarningValidation:AbstractValidator<DeleteWarningCommand>
{

    public DeleteWarningValidation(IWarningRepository warningRepository)
    {
        
        
        
        RuleFor(x=>x.Id)
            .NotEmpty()
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(id=>warningRepository.IsExists(id))
            .WithMessage("this warning is not exists");
        
    }
    
}