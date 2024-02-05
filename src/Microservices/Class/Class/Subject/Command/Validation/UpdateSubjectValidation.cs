using Class.Repository.Subject;
using ClassDomain.Model.Subject.Command;
using FluentValidation;

namespace Class.Subject.Command.Validation;

public class UpdateSubjectValidation:AbstractValidator<UpdateSubjectCommand>
{

    public UpdateSubjectValidation(ISubjectRepository subjectRepository)
    {
        
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id should be not empty")
            .NotNull()
            .WithMessage("Id should be not null")
            .Must(x=>subjectRepository.IsExists(x))
            .WithMessage("this subject is not exists in our data");

        
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("Name should be not empty")
            .NotNull()
            .WithMessage("Name should be not null")
            .Must(x=>!subjectRepository.IsExists(x.Id,x.Name))
            .OverridePropertyName("Name")
            .WithMessage("this subject is already exists in our data");

    }
    
}