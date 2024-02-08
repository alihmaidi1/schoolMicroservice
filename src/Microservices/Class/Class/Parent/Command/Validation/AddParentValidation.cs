using Class.Repository.Parent;
using ClassDomain.Model.Parent.Command;
using FluentValidation;

namespace Class.Parent.Command.Validation;

public class AddParentValidation:AbstractValidator<AddParentCommand>
{

    public AddParentValidation(IParentRepository parentRepository)
    {

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("parent name should be not empty")
            .NotNull()
            .WithMessage("parent name should be not null");


        
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("parent email should be not empty")
            .NotNull()
            .WithMessage("parent email should be not null")
            .Must(Email=>!parentRepository.IsExists(Email))
            .WithMessage("this email was already exists in our data");

        
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("parent password should be not empty")
            .NotNull()
            .WithMessage("parent password should be not null")
            .MinimumLength(8)
            .WithMessage("password length should be at least 8 charecter");

    }
    
}