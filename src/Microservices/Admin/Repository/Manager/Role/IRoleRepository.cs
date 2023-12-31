using Common.EntityOperation;
using Domain.Entities.Manager.Role;
using Dto.Manager.Role;
using Repository.Base;

namespace Repository.Manager.Role;

public interface IRoleRepository:IgenericRepository<Domain.Entities.Manager.Role.Role>
{


    public bool AddRole(string name, List<string> Permissions);

    public bool UpdateRole(RoleID Id,string name, List<string> Permissions);

    public bool IsExists(string Name);

    public bool IsExists(RoleID Id);
    
    public bool IsExists(string Name,RoleID Id);


    public bool Delete(RoleID Id);


    public PageList<GetAllRole> GetAll(string? OrderBy, int? pageNumber, int? pageSize);

    public PageList<GetAllAdminByRole> GetAdminById(RoleID Id,string? OrderBy, int? pageNumber, int? pageSize);

}