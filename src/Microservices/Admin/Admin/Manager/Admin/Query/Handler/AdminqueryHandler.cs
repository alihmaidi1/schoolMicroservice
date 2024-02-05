using Common.CQRS;
using Common.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Model.Manager.Admin.Command;
using Model.Manager.Admin.Query;
using Repository.Manager.Admin;

namespace Admin.Manager.Admin.Query.Handler;

public class AdminqueryHandler:OperationResult,
    IQueryHandler<GetAllAdminQuery>

{
    private IAdminRepository adminRepository;
    public AdminqueryHandler(IAdminRepository adminRepository)
    {


        this.adminRepository = adminRepository;


    }
    
    public async Task<JsonResult> Handle(GetAllAdminQuery request, CancellationToken cancellationToken)
    {

        var Result = adminRepository.GetAlladmin(request.OrderBy, request.PageNumber, request.PageSize);


        return Success(Result, "this is all admin");
    }
}