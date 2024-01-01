using Common.EntityOperation;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Manager.Role;
using Dto.Manager.Admin;
using Dto.Manager.Role;
using Repository.Base;

namespace Repository.Manager.Admin;

public interface IAdminRepository:IgenericRepository<Domain.Entities.Manager.Admin.Admin>
{
    
    
    public bool IsEmailExists(string Email);

    public bool IsExists(AdminID Id);

    public bool IsEmailExists(string Email,AdminID Id);


    public Domain.Entities.Manager.Admin.Admin GetById(string Id);
    public bool ChangePassword(string Id,string password);

    public Domain.Entities.Manager.Admin.Admin GetByEmail(string Email);

    public Task<bool> SendResetCode(string email);

    public bool CheckCode(string code);
    
    public bool Logout(string Token);



    public bool Add(string Email,string Password,RoleID roleId,string Name);

    public bool Update(AdminID Id, string Email,string Password,RoleID roleId,string Name);

    
    public PageList<GetAllAdmin> GetAlladmin(string? OrderBy, int? pageNumber, int? pageSize);

}