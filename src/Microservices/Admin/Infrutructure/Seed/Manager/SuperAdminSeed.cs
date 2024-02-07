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

            
            Role role2 = new Role()
            {

                Name = "role2",
                
                Permissions = Permissions

            };
            List<Admin> Admins = new List<Admin>();
            
            Admins.Add( new Admin()
            {
                Name =RoleEnum.SuperAdmin.ToString(),
                Email = "alihmaidi095@gmail.com",
                Password = "12345678",
                Role = role,
                Id = new Guid("f1cfc8cb-df51-425c-a37c-db1db5519127")
            });

            Admins.Add(new Admin()
            {

                
                Name ="Ali",
                Email = "alihmaidi10@gmail.com",
                Password = "12345678",
                Role = role2,
                Id = new Guid("f1cfc8cb-df51-425c-a37c-db1db5519128")


            });
            
            ;
            
            
            
            
            
            context.AddRange(Admins);
            context.SaveChanges();

        }
        
    }
    
}