using Domain.Model.Teacher.Command;
using FluentValidation;
using Teacher.Repository.Teacher;

namespace Teacher.Teacher.Command.Validation;

public class UpdateTeacherValidation:AbstractValidator<UpdateTeacherCommand>
{

    public UpdateTeacherValidation(ITeacherRepository teacherRepository)
    {
        
        RuleFor(x=>x.Id)
            .NotNull()
            .WithMessage("id should be not null")
            .NotEmpty()
            .WithMessage("id should be not empty")
            .Must(id=>teacherRepository.IsExists(id))
            .WithMessage("id is not exists in our data");
        
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("name should be not null")
            .NotEmpty()
            .WithMessage("name should be not empty");

        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("email should be not empty")
            .NotNull()
            .WithMessage("email should be not null")
            .Must(x=>!teacherRepository.IsUnique(x.Id,x.Email));
        
        
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