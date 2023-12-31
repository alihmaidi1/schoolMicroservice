using System.Linq.Expressions;
using Dto.Manager.Role;

namespace Repository.Manager.Role.Operation;

public static class RoleQuery
{

    public static Expression<Func<Domain.Entities.Manager.Role.Role, GetAllRole>> ToGetAllRole = role =>
        new GetAllRole()
        {

            Id = role.Id.Value,
            Name = role.Name,
            Permissions = role.Permissions,
            CreatedAt = role.DateCreated
        };

    public static Expression<Func<Domain.Entities.Manager.Admin.Admin, GetAllAdminByRole>> ToGetAllAdmin = admin =>
        new GetAllAdminByRole()
        {
            Id = admin.Id.Value,
            Name = admin.Name,
            Email = admin.Email,
            CreatedAt = admin.DateCreated
        };

}