using Class.Repository.Parent;
using Class.Repository.Student;
using ClassDomain.Model.Student.Command;
using FluentValidation;

namespace Class.Student.Command.Validation;

public class UpdateStudentValidation:AbstractValidator<UpdateStudentCommand>
{


    public UpdateStudentValidation(IParentRepository parentRepository,IStudentRepository studentRepository)
    {

        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage("id should be not null")
            .NotEmpty()
            .WithMessage("id should be not empty")
            ;
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("email should be not empty")
            .NotNull()
            .WithMessage("email should be not null");


        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("name should be not empty")
            .NotNull()
            .WithMessage("name should be not null");

        RuleFor(x => x)
            .Must(x => !studentRepository.IsExists(x.Id, x.Email))
            .WithMessage("this email should be unique")
            .OverridePropertyName("Email");
        

        RuleFor(x => x.ParentId)
            .NotNull()
            .WithMessage("parent id should be not null")
            .NotEmpty()
            .WithMessage("parent id should be not empty")
            .Must(id=>parentRepository.IsExists(id))
            .WithMessage("parent id is not exists in our data");
    }
    
}