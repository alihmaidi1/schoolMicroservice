using System.Security.Claims;
using Common.CQRS;
using Common.OperationResult;
using Domain.Model.Warning.Query;
using Domain.Repository.Warning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teacher.Warning.Query.Handler;

public class WarningQueryHandler:OperationResult,
    IQueryHandler<GetWarningQuery>
{
    private IHttpContextAccessor HttpContextAccessor;
    private IWarningRepository warningRepository;
    public WarningQueryHandler(IHttpContextAccessor HttpContextAccessor,IWarningRepository warningRepository)
    {
        
        this.warningRepository = warningRepository;
        this.HttpContextAccessor = HttpContextAccessor;

    }
    public async Task<JsonResult> Handle(GetWarningQuery request, CancellationToken cancellationToken)
    {
        Guid TeacherId = new Guid(HttpContextAccessor.HttpContext?.User?.Claims?.First(x => x.Type==ClaimTypes.NameIdentifier).Value);
        var Result=warningRepository.GetWarnings(TeacherId,request.PageNumber,request.PageSize);
        return Success(Result,"this is all your Warnings");

    }
}