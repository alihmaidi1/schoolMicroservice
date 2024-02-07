using Class.Repository.ClassYear;
using ClassDomain.Model.ClassYear.Query;
using Common.CQRS;
using Common.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Class.ClassYear.Query.Handler;

public class ClassYearQueryHandler:OperationResult,
    IQueryHandler<GetAllClassYearQuery>
{
    private IClassYearRepository ClassYearRepository;
    public ClassYearQueryHandler(IClassYearRepository ClassYearRepository)
    {

        this.ClassYearRepository = ClassYearRepository;

    }
    
    public async Task<JsonResult> Handle(GetAllClassYearQuery request, CancellationToken cancellationToken)
    {

        var Result = ClassYearRepository.GetAllClassYear(request.ClassId,request.PageNumber,request.PageSize);
        return Success(Result,"this is all class year");
    }
}