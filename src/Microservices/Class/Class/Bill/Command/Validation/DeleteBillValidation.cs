using Class.Repository.Bill;
using ClassDomain.Model.Bill.Command;
using FluentValidation;

namespace Class.Bill.Command.Validation;

public class DeleteBillValidation:AbstractValidator<DeleteBillCommand>
{


    public DeleteBillValidation(IBillRepository billRepository)
    {
        
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("year id should be not empty")
            .NotNull()
            .WithMessage("year id should be not null")
            .Must(ID=>billRepository.IsExists(ID))
            .WithMessage("this year is not exists");

    }
    
}