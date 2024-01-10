using Common.ExtensionMethod;
using Domain.Model.Teacher.Query;
using FluentValidation;
using Teacher.Repository.Teacher;

namespace Teacher.Teacher.Query.Validation;

public class GetAllTeacherValidation:AbstractValidator<GetAllTeacher>
{


    public GetAllTeacherValidation()
    {
        
        RuleFor(x => x.OrderBy)
            .Must(x => CrudOpterationRule.IsValidOrder(x, TeacherSorting.OrderBy))
            .WithMessage("order by string is not valid");

        
        
    }
    
    
    
}