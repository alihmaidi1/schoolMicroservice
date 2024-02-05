using Class.Repository.Subject;
using ClassDomain.Model.Subject.Command;
using FluentValidation;

namespace Class.Subject.Command.Validation;

public class AddSubjectValidation:AbstractValidator<AddSubjectCommand>
{

    public AddSubjectValidation(ISubjectRepository subjectRepository)
    {

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name should be not empty")
            .NotNull()
            .WithMessage("Name should be not null")
            .Must(x=>!subjectRepository.IsExists(x))
            .WithMessage("this subject is already exists in our data");


    }
    
}