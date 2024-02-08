using Class.Repository.Semester;
using ClassDomain.Model.Semester.Command;
using FluentValidation;

namespace Class.Semester.Command.Validation;

public class DeleteSemesterValidation:AbstractValidator<DeleteSemesterCommand>
{

    public DeleteSemesterValidation(ISemesterRepository semesterRepository)
    {
        RuleFor(x=>x.Id)
            .NotEmpty()
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(id=>semesterRepository.IsExists(id))
            .WithMessage("this semester is not exists in our data");

        
    }
    
}