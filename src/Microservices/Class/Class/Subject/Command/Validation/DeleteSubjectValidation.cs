using Class.Repository.Subject;
using ClassDomain.Model.Subject.Command;
using FluentValidation;

namespace Class.Subject.Command.Validation;

public class DeleteSubjectValidation:AbstractValidator<DeleteSubjectCommand>
{
    public DeleteSubjectValidation(ISubjectRepository subjectRepository)
    {
        
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id should be not empty")
            .NotNull()
            .WithMessage("Id should be not null")
            .Must(x=>subjectRepository.IsExists(x))
            .WithMessage("this subject is not exists in our data");

        
    }
    
    
}