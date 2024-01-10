using Domain.Model.Teacher.Command;
using FluentValidation;
using Teacher.Repository.Teacher;

namespace Teacher.Teacher.Command.Validation;

public class ChangeTeacherStatusValidation:AbstractValidator<ChangeTeacherStatusCommand>
{


    public ChangeTeacherStatusValidation(ITeacherRepository teacherRepository)
    {
        
        
        
        RuleFor(x=>x.Id)
            .NotNull()
            .WithMessage("id should be not null")
            .NotEmpty()
            .WithMessage("id should be not empty")
            .Must(id=>teacherRepository.IsExists(id))
            .WithMessage("id is not exists in our data");


        RuleFor(x => x.Status)
            .NotNull()
            .WithMessage("id should be not null")
            .NotEmpty()
            .WithMessage("id should be not empty");

    }
    
}