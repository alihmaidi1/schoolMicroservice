using Class.Repository.Parent;
using ClassDomain.Model.Parent.Command;
using FluentValidation;

namespace Class.Parent.Command.Validation;

public class UpdateParentValidation:AbstractValidator<UpdateParentCommand>
{

    
    public UpdateParentValidation(IParentRepository parentRepository)
    {
        
        
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("parent id should be not empty")
            .NotNull()
            .WithMessage("parent id should be not null")
            .Must(id=>parentRepository.IsExists(id))
            .WithMessage("parent id is not exists in our data");

        
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("parent name should be not empty")
            .NotNull()
            .WithMessage("parent name should be not null");


        
        
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("parent email should be not empty")
            .NotNull()
            .WithMessage("parent email should be not null")
            .Must(x=>!parentRepository.IsExists(x.Email,x.Id))
            .OverridePropertyName("Email")
            .WithMessage("this email was already exists in our data");

        
    }
    
}