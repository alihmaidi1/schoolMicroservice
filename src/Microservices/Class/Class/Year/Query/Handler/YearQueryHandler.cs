using Class.Repository.Year;
using ClassDomain.Model.Year.Command;
using ClassDomain.Model.Year.Query;
using Common.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Class.Year.Query.Handler;

public class YearQueryHandler:OperationResult,
    IRequestHandler<GetAllYearQuery, JsonResult>
{
    private IYearRepository YearRepository;
    public YearQueryHandler(IYearRepository YearRepository)
    {

        this.YearRepository = YearRepository;

    }
    
    public async Task<JsonResult> Handle(GetAllYearQuery request, CancellationToken cancellationToken)
    {

        var Result=YearRepository.GetAllYear(request.OrderBy,request.PageNumber,request.PageSize);
        return Success(Result,"this is all year");

    }
}