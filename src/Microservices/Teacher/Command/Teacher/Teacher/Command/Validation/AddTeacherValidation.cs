using Domain.Model.Teacher.Command;
using FluentValidation;
using Teacher.Repository.Teacher;

namespace Teacher.Teacher.Command.Validation;

public class AddTeacherValidation:AbstractValidator<AddTeacherCommand>
{

    public AddTeacherValidation(ITeacherRepository teacherRepository)
    {

        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("name should be not null")
            .NotEmpty()
            .WithMessage("name should be not empty");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("email should be not empty")
            .NotNull()
            .WithMessage("email should be not null")
            .Must(email=>!teacherRepository.IsExists(email));

        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("status should be not empty")
            .NotNull()
            .WithMessage("status should be not null");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("password should be not empty")
            .NotNull()
            .WithMessage("password should be not null")
            .MinimumLength(8)
            .WithMessage("password should be at leat 8 charecter");

        

    }
    
}