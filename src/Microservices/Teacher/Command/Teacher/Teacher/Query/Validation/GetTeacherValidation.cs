using Domain.Model.Teacher.Query;
using FluentValidation;
using Teacher.Repository.Teacher;

namespace Teacher.Teacher.Query.Validation;

public class GetTeacherValidation:AbstractValidator<GetTeacherQuery>
{

    public GetTeacherValidation(ITeacherRepository teacherRepository)
    {

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(id=>teacherRepository.IsExists(id))
            .WithMessage("this teacher is not exists in our data");

    }
    
    
}