using Class.Repository.Stage;
using ClassDomain.Model.Stage.Query;
using FluentValidation;

namespace Class.Stage.Query.Validation;

public class GetStageValidation:AbstractValidator<GetStageQuery>
{

    public GetStageValidation(IStageRepository stageRepository)
    {

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(x=>stageRepository.IsExists(x))
            .WithMessage("id is not exists in our data");
        
    }
    
}