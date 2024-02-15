using Class.Repository.Stage;
using Class.Repository.Student;
using ClassDomain.Model.Student.Query;
using Common.ExtensionMethod;
using FluentValidation;

namespace Class.Student.Query;

public class GetAllStudentValidation:AbstractValidator<GetAllStudentQuery>
{


    public GetAllStudentValidation()
    {
        
        
        RuleFor(x => x.OrderBy)
            .Must(x => CrudOpterationRule.IsValidOrder(x, StudentSorting.OrderBy))
            .WithMessage("order by string is not valid");

        
    }
    
    
}