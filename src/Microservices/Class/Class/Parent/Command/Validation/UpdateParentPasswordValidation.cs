using Class.Repository.Parent;
using ClassDomain.Model.Parent.Command;
using FluentValidation;

namespace Class.Parent.Command.Validation;

public class UpdateParentPasswordValidation:AbstractValidator<UpdateParentPasswordCommand>
{

    public UpdateParentPasswordValidation(IParentRepository parentRepository)
    {
        
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("parent id should be not empty")
            .NotNull()
            .WithMessage("parent id should be not null")
            .Must(id=>parentRepository.IsExists(id))
            .WithMessage("parent id is not exists in our data");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("parent password should be not empty")
            .NotNull()
            .WithMessage("parent password should be not null")
            .MinimumLength(8)
            .WithMessage("password length should be at least 8 charecter");


        
        
    }
    
}