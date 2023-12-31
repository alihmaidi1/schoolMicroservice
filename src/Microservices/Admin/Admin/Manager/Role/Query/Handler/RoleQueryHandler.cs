using System.Reflection.Metadata.Ecma335;
using Common.OperationResult;
using Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Model.Manager.Role.Query;
using Repository.Manager.Role;

namespace Admin.Manager.Role.Query.Handler;

public class RoleQueryHandler:OperationResult,
    IRequestHandler<GetPermissionsQuery, JsonResult>,
    IRequestHandler<GetRolesQuery, JsonResult>,
    IRequestHandler<GetManagerByRoleQuery, JsonResult>


{
    private IRoleRepository roleRepository;

    public RoleQueryHandler(IRoleRepository roleRepository)
    {

        this.roleRepository = roleRepository;

    }
    
    
    
    public async Task<JsonResult> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
    {

        List<string> Permissions = Enum.GetNames(typeof(PermissionEnum)).ToList();

        return Success(Permissions, "this is all permissions");

    }

    public async Task<JsonResult> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var Result = roleRepository.GetAll(request.OrderBy, request.PageNumber, request.PageSize);

        return Success(Result,"this is all role");

    }

    public async Task<JsonResult> Handle(GetManagerByRoleQuery request, CancellationToken cancellationToken)
    {

        var Result = roleRepository.GetAdminById(request.Id, request.OrderBy, request.PageNumber, request.PageSize);
        return Success(Result,"this is all admin");

    }
}