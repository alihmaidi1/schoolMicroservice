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
                Role = role

            };

            context.Admins.Add(SuperAdmin);
            context.SaveChanges();

        }
        
    }
    
}