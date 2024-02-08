using Class.Repository.Parent;
using ClassDomain.Model.Parent.Command;
using FluentValidation;

namespace Class.Parent.Command.Validation;

public class DeleteParentValidation:AbstractValidator<DeleteParentCommand>
{

    public DeleteParentValidation(IParentRepository parentRepository)
    {
        
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("parent id should be not empty")
            .NotNull()
            .WithMessage("parent id should be not null")
            .Must(id=>parentRepository.IsExists(id))
            .WithMessage("parent id is not exists in our data");

        
    }
    
    
}