using Common.Enum;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Manager.Role;
using Domain.Enum;

namespace Infrutructure.Seed.Manager;

public static class SuperAdminSeed
{
    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.Admins.Any())
        {

            List<string> Permissions = Enum.GetNames(typeof(PermissionEnum)).ToList();
            Role role = new Role()
            {

                Name = RoleEnum.SuperAdmin.ToString(),
                
                Permissions = Permissions

            };
            Admin SuperAdmin = new Admin()
            {
                Name =RoleEnum.SuperAdmin.ToString(),
                Email = "alihmaidi095@gmail.com",
                Password = "12345678",
                Role = role,
                Id = new Guid("f1cfc8cb-df51-425c-a37c-db1db5519127")
            };
            
            
            context.Admins.Add(SuperAdmin);
            context.SaveChanges();

        }
        
    }
    
}