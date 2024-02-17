using Class.Repository.Student;
using ClassDomain.Model.Student.Command;
using FluentValidation;

namespace Class.Student.Command.Validation;

public class DeleteStudentValidation:AbstractValidator<DeleteStudentCommand>
{


    public DeleteStudentValidation(IStudentRepository studentRepository)
    {

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(id=>studentRepository.IsExists(id));
    }
    
    
    
    
}