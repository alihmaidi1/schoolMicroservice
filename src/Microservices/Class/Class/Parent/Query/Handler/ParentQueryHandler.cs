using Class.Repository.Parent;
using ClassDomain.Model.Parent.Query;
using Common.CQRS;
using Common.OperationResult;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Class.Parent.Query.Handler;

public class ParentQueryHandler:OperationResult,
    IQueryHandler<GetAllParentsQuery>,
    IQueryHandler<GetParentQuery>

{
    private IParentRepository ParentRepository;
    public ParentQueryHandler(IParentRepository ParentRepository)
    {

        this.ParentRepository = ParentRepository;

    }
    
    public async Task<JsonResult> Handle(GetAllParentsQuery request, CancellationToken cancellationToken)
    {

        var Result = ParentRepository.GetAllParent(request.OrderBy,request.PageNumber,request.PageSize);
        return Success(Result,"this is all parent");

    }

    public async Task<JsonResult> Handle(GetParentQuery request, CancellationToken cancellationToken)
    {
        var Result = ParentRepository.GetParent(request.Id);
        return Success(Result,"this is parent info");
    }
}