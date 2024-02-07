using Common.Entity.Entity;

namespace Domain.Entities.Manager.Role;

public class Role:BaseEntity<RoleID>
{
    
    
    public Role()
    {

        Id = new RoleID(Guid.NewGuid());
        Admins = new HashSet<Admin.Admin>();
    }

    public string Name { get; set; }

    public  ICollection<Admin.Admin>? Admins { get; set; }
    public List<string> Permissions { get; set; }

    
}