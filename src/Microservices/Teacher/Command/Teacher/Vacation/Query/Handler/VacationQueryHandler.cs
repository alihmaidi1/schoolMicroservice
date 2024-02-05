using System.Security.Claims;
using Common.CQRS;
using Common.OperationResult;
using Domain.Model.Vacation.Query;
using Domain.Repository.Vacation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teacher.Vacation.Query.Handler;

public class VacationQueryHandler:OperationResult,
    IQueryHandler<GetVacationQuery>
{
    private IHttpContextAccessor httpContextAccessor;
    private IVacationRepository vacationRepository;
    public VacationQueryHandler(IHttpContextAccessor httpContextAccessor,IVacationRepository vacationRepository)
    {

        this.vacationRepository = vacationRepository;
        this.httpContextAccessor = httpContextAccessor;

    }
    
    
    public async Task<JsonResult> Handle(GetVacationQuery request, CancellationToken cancellationToken)
    {
        
        Guid TeacherId = new Guid(httpContextAccessor.HttpContext?.User?.Claims?.First(x => x.Type==ClaimTypes.NameIdentifier).Value);

        var Result=vacationRepository.Vacations(TeacherId,request.PageNumber,request.PageSize);

        return Success(Result,"this is all your vacations");
    }
}