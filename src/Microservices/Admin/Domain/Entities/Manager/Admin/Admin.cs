using Api;
using Common.Entity.Entity;
using Domain.Entities.Manager.Role;
using EntityFrameworkCore.EncryptColumn.Attribute;

namespace Domain.Entities.Manager.Admin;

public class Admin:AccountEntity<AdminID>
{
    
    public Admin()
    {

        Id = new AdminID(Guid.NewGuid());

        RefreshTokens = new HashSet<AdminRefreshToken>();
    }

    
    
    public string Name { get; set; }
    
    public string Email { get; set; }

    public RoleID RoleId { get; set; }
    public  Role.Role Role { set; get; }
    
    
    [EncryptColumn]

    public string? ResetCode { get; set; }

    
    
    [EncryptColumn]

    public string Password { get; set; }
    
    public  ICollection<AdminRefreshToken>? RefreshTokens { get; set; }


    
}