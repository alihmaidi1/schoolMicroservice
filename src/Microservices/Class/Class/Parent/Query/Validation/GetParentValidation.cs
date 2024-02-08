using Class.Repository.Parent;
using ClassDomain.Model.Parent.Query;
using FluentValidation;

namespace Class.Parent.Query.Validation;

public class GetParentValidation:AbstractValidator<GetParentQuery>
{

    public GetParentValidation(IParentRepository parentRepository)
    {


        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("parent id should be not empty")
            .NotNull()
            .WithMessage("parent id should be not null")
            .Must(ID=>parentRepository.IsExists(ID))
            .WithMessage("this parent is not exists in our data");



    }
    
    
}