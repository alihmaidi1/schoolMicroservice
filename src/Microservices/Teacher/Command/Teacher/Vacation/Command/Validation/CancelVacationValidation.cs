using System.Security.Claims;
using Domain.Model.Vacation.Command;
using Domain.Repository.Vacation;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Teacher.Vacation.Command.Validation;

public class CancelVacationValidation:AbstractValidator<CancelVacationCommand>
{

    public CancelVacationValidation(IVacationRepository vacationRepository,IHttpContextAccessor _httpContextAccessor)
    {
        
        Guid TeacherId = new Guid(_httpContextAccessor.HttpContext?.User?.Claims?.First(x => x.Type==ClaimTypes.NameIdentifier).Value);
        RuleFor(x=>x)
            
            .NotEmpty()
            .WithMessage("vacation id should be not empty")
            .NotNull()
            .WithMessage("vacation id should be not null")
            .Must(x=>vacationRepository.IsExistsAndNotProccessed(x.Id,TeacherId))
            .OverridePropertyName("Id")
            .WithMessage("vacation  should be belong for you and not processed");


    }
    
}