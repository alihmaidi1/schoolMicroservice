using System.Security.Claims;
using Common.OperationResult;
using Domain.Model.Warning.Command;
using Domain.Repository.Warning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teacher.Warning.Command.Handler;

public class WarningCommandHandler:OperationResult,
    IRequestHandler<AddWarningCommand, JsonResult>,
    IRequestHandler<DeleteWarningCommand, JsonResult>

    
{
    private IWarningRepository WarningRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public WarningCommandHandler(IHttpContextAccessor _httpContextAccessor,IWarningRepository WarningRepository)
    {

        this._httpContextAccessor = _httpContextAccessor;
        this.WarningRepository = WarningRepository;

    }
    
    
    public async Task<JsonResult> Handle(AddWarningCommand request, CancellationToken cancellationToken)
    {
     
        var ManagerID = _httpContextAccessor.HttpContext.User.Claims.Single(x=>x.Type==ClaimTypes.NameIdentifier).Value;
        WarningRepository.AddAsync(new Domain.Entities.Warning.Warning()
        {

            ManagerId = new Guid(ManagerID),
            Reason = request.Reson,
            TeacherId = request.TeacherID
            
        });

        return Success("the warning was added successfully");
    }

    public async Task<JsonResult> Handle(DeleteWarningCommand request, CancellationToken cancellationToken)
    {

        WarningRepository.DeleteAsync(new Domain.Entities.Warning.Warning()
        {

            Id = request.Id

        });
        
        return Success("warning was deleted successfully");
    }
}