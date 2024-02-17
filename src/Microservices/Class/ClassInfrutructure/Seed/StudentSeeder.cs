using ClassDomain.Entities.Parent;
using ClassDomain.Entities.Student;
using ClassInfrutructure.Data;

namespace ClassInfrutructure.Seed;

public static class StudentSeeder
{


    public static async Task seedData(ApplicationDbContext context)
    {


        if (!context.Students.Any())
        {
            List<Parent> parents = context.Parents.ToList();
            List<Student> students = StudentFaker
                .GetStudentFaker(parents)
                .Generate(20)
                .DistinctBy(x=>x.Email)
                .DistinctBy(x=>x.Number)
                .ToList();
            context.Students.AddRange(students);
            context.SaveChanges();

        }
    }

}