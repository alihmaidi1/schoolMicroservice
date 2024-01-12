using Class.Repository.Stage;
using ClassDomain.Model.Stage.Query;
using Common.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Class.Stage.Query.Handler;

public class StageQueryHandler:OperationResult,
    IRequestHandler<GetAllStageQuery, JsonResult>,
    IRequestHandler<GetStageQuery, JsonResult>

{
    private IStageRepository StageRepository;
    public StageQueryHandler(IStageRepository StageRepository)
    {

        this.StageRepository = StageRepository;

    }
    
    public async Task<JsonResult> Handle(GetAllStageQuery request, CancellationToken cancellationToken)
    {

        var Result=StageRepository.GetAllStage(request.OrderBy,request.PageNumber,request.PageSize);
        return Success(Result,"this is all stage");
    }

    public async Task<JsonResult> Handle(GetStageQuery request, CancellationToken cancellationToken)
    {
        var Result = StageRepository.GetStage(request.Id);
        return Success(Result,"this is your stage");
    }
}