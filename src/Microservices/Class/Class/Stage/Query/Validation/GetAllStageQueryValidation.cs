using Class.Repository.Stage;
using ClassDomain.Model.Stage.Query;
using Common.ExtensionMethod;
using FluentValidation;

namespace Class.Stage.Query.Validation;

public class GetAllStageQueryValidation:AbstractValidator<GetAllStageQuery>
{

    public GetAllStageQueryValidation()
    {
        
        RuleFor(x => x.OrderBy)
            .Must(x => CrudOpterationRule.IsValidOrder(x, StageSorting.OrderBy))
            .WithMessage("order by string is not valid");

    }
    
}