using ClassDomain.Entities.ClassYear;
using ClassDomain.Entities.Semester;
using ClassInfrutructure.Data;

namespace ClassInfrutructure.Seed;

public static class SemesterSeeder
{

    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.Semesters.Any())
        {

            List<ClassYear> classYears = context.ClassYears.ToList();
            List<Semester> semesters = SemesterFaker
                .GetSemesterFaker(classYears)
                .Generate(20)
                .DistinctBy(x => new { x.Name, x.ClassYearId })
                
                .ToList();
            context.Semesters.AddRange(semesters);
            context.SaveChanges();
        }
    }

}