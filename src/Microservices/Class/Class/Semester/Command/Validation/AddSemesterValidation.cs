using Class.Repository.ClassYear;
using Class.Repository.Semester;
using ClassDomain.Model.Semester.Command;
using FluentValidation;

namespace Class.Semester.Command.Validation;

public class AddSemesterValidation:AbstractValidator<AddSemesterCommand>
{

    public AddSemesterValidation(ISemesterRepository semesterRepository,IClassYearRepository classYearRepository)
    {


        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name should be not empty")
            .NotNull()
            .WithMessage("Name should be not null");


        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("data should be not empty")
            .NotNull()
            .WithMessage("data should be not null")
            .Must(x=>!semesterRepository.IsExists(x.Name,x.ClassYearId))
            .OverridePropertyName("ClassYearId")
            .WithMessage("this semester is already exists in this class year");

        RuleFor(x => x.ClassYearId)
            .NotEmpty()
            .WithMessage("class year id should be not empty")
            .NotNull()
            .WithMessage("class year id should be not null")
            .Must(id=>classYearRepository.IsExists(id))
            .WithMessage("this class year id is not exists in our data");

    }
    
}