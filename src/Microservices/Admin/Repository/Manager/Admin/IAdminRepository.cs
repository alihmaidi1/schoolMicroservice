using Domain.Entities.Manager.Admin;
using Repository.Base;

namespace Repository.Manager.Admin;

public interface IAdminRepository:IgenericRepository<Domain.Entities.Manager.Admin.Admin>
{
    
    
    public bool IsEmailExists(string Email);



    public Domain.Entities.Manager.Admin.Admin GetById(string Id);
    public bool ChangePassword(string Id,string password);

    public Domain.Entities.Manager.Admin.Admin GetByEmail(string Email);

    public Task<bool> SendResetCode(string email);

    public bool CheckCode(string code);
    
    public bool Logout(string Token);

    
}