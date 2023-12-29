using Repository.Base;

namespace Repository.Manager.Admin;

public interface IAdminRepository:IgenericRepository<Domain.Entities.Manager.Admin.Admin>
{
    
    
    public bool IsEmailExists(string Email);


    public Domain.Entities.Manager.Admin.Admin GetByEmail(string Email);


    public bool Logout(string Token);

    
}