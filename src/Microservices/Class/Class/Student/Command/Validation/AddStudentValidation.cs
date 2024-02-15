using Class.Repository.Parent;
using Class.Repository.Student;
using ClassDomain.Model.Student.Command;
using FluentValidation;
using RabbitMQ.Client;

namespace Class.Student.Command.Validation;

public class AddStudentValidation:AbstractValidator<AddStudentCommand>
{

    public AddStudentValidation(IStudentRepository studentRepository,IParentRepository parentRepository)
    {


        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("email address should be not empty")
            .NotNull()
            .WithMessage("email address should be not null")
            .Must(email=>!studentRepository.IsExists(email))
            .WithMessage("this email is already exists in our data");
        
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("password  should be not empty")
            .NotNull()
            .WithMessage("password  should be not null")
            .MinimumLength(8)
            .WithMessage("password should be at least 8 charectar");

        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("name  should be not empty")
            .NotNull()
            .WithMessage("name  should be not null");


        RuleFor(x => x.ParentId)
            .NotEmpty()
            .WithMessage("parnet id should be not empty")
            .NotNull()
            .WithMessage("parent id should be not null")
            .Must(parentid=>parentRepository.IsExists(parentid))
            .WithMessage("this parent id  is not exists  in our data");


    }
    
    
    
}