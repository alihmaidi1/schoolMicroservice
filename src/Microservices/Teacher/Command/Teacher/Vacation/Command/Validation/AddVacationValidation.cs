using Domain.Model.Vacation.Command;
using Domain.Repository.Year;
using FluentValidation;
using Teacher.Repository.Teacher;

namespace Teacher.Vacation.Command.Validation;

public class AddVacationValidation:AbstractValidator<AddVacationCommand>
{

    public AddVacationValidation(ITeacherRepository teacherRepository,IYearRepository yearRepository)
    {

        RuleFor(x => x.Reason)
            .NotEmpty()
            .WithMessage("reason should be not empty")
            .NotNull()
            .WithMessage("reason should be not null");
        
        RuleFor(x => x.TeacherId)
            .NotEmpty()
            .WithMessage("teacher id should be not empty")
            .NotNull()
            .WithMessage("teacher id should be not null")
            .Must(id=>teacherRepository.IsExists(id))
            .WithMessage("this teacher is not exists in our data");


        RuleFor(x => x.YearId)
            .NotEmpty()
            .WithMessage("year id should be not empty")
            .NotNull()
            .WithMessage("year id should be not null")
            .Must(id=>yearRepository.IsExists(id))
            .WithMessage("this year is not exists in our data");


    }
    
}