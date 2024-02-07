using System.Linq.Expressions;
using Dto.Manager.Admin;
using Dto.Manager.Role;

namespace Repository.Manager.Admin.Operation;

public static class AdminQuery
{
    
    public static Expression<Func<Domain.Entities.Manager.Admin.Admin, GetAllAdmin>> ToGetAllAdmin = admin =>
        new GetAllAdmin()
        {
            Id = admin.Id.Value,
            Name = admin.Name,
            Email = admin.Email,
            CreatedAt = admin.DateCreated
        };

    
}