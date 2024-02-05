using Domain.Entities.Teacher;
using Teacherinfrutructure.Data;

namespace Teacherinfrutructure.Seed;

public static class TeacherSeeder
{
    
    
    public static async Task seedData(ApplicationDbContext context)
    {

        
        if (!context.Teachers.Any())
        {

            List<Teacher> teachers = TeacherFaker.GetBrandFaker().Generate(10);
            context.AddRange(teachers);
            context.SaveChanges();

        }
        
    }
    
}