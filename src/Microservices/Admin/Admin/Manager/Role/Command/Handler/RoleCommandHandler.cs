using Common.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Model.Manager.Role.Command;
using Model.Manager.Role.Query;
using Repository.Manager.Role;

namespace Admin.Manager.Role.Command.Handler;

public class RoleCommandHandler:OperationResult,
    IRequestHandler<AddRoleCommand, JsonResult>,
    IRequestHandler<UpdateRoleCommand, JsonResult>,
    IRequestHandler<DeleteRoleCommand, JsonResult>


{
    private IRoleRepository roleRepository;
    public RoleCommandHandler(IRoleRepository roleRepository)
    {

        this.roleRepository = roleRepository;


    }
    
    public async Task<JsonResult> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {

        roleRepository.AddRole(request.Name, request.Permissions);
        return Success("role was added successfully");
    }

    public async Task<JsonResult> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        roleRepository.UpdateRole(request.Id,request.Name,request.Permissions);
        return Success("role was updated successfully");
    }

    public async Task<JsonResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {

        
        roleRepository.Delete(request.Id);
        return Success("this role was deleted successfully");

    }
}