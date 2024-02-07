using Domain.Entities.Manager;
using Domain.Entities.Teacher;
using Domain.Entities.Warning;
using Teacherinfrutructure.Data;

namespace Teacherinfrutructure.Seed;

public static class WarningSeeder
{

    public static async Task seedData(ApplicationDbContext context)
    {
        
        
        if (!context.Warnings.Any())
        {

            List<Teacher> teachers = context.Teachers.ToList();
            List<Manager> managers = context.Managers.ToList();
            List<Warning> warnings = WarningFaker.GetBrandFaker(teachers,managers).Generate(10);
            context.AddRange(warnings);
            context.SaveChanges();
        }

    }
    
    
}