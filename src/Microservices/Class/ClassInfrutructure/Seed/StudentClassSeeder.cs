using ClassDomain.Entities.ClassYear;
using ClassDomain.Entities.Student;
using ClassDomain.Entities.StudentClass;
using ClassInfrutructure.Data;

namespace ClassInfrutructure.Seed;

public static class StudentClassSeeder
{

    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.StudentClasses.Any())
        {

            List<Student> students = context.Students.ToList();
            List<ClassYear> classYears = context.ClassYears.ToList();
            List<StudentClass> studentClasses=StudentClassFaker
                .GetStudentClassFaker(students,classYears)
                .Generate(20)
                .DistinctBy(x=>new {x.ClassYearId,x.StudentId})
                .ToList();

            context.StudentClasses.AddRange(studentClasses);
            context.SaveChanges();
            
        }
    }
}