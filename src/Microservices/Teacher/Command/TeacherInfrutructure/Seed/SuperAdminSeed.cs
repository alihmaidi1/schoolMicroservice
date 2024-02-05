using Common.Enum;
using Domain.Entities.Manager;

namespace Teacherinfrutructure.Seed;

public static class SuperAdminSeed
{
    
    public static async Task seedData(ApplicationDbContext context)
    {
        
        if (!context.Managers.Any())
        {
            List<Manager> managers = new List<Manager>()
            {

                new Manager()
                {
                Name =RoleEnum.SuperAdmin.ToString(),
                ManagerId = new Guid("f1cfc8cb-df51-425c-a37c-db1db5519127")
                },
                
                new Manager()
                {
                    Name ="Ali",
                    ManagerId = new Guid("f1cfc8cb-df51-425c-a37c-db1db5519128")
                },




            };
            
            
            
            context.Managers.AddRange(managers);
            context.SaveChanges();

        }
        
    }
}