using ClassDomain.Entities.Bill;
using ClassDomain.Entities.Class;
using ClassDomain.Entities.StageClass;
using ClassDomain.Entities.Year;
using ClassInfrutructure.Data;
using Common.ExtensionMethod;

namespace ClassInfrutructure.Seed;

public static class ClassYearSeeder
{
    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.ClassYears.Any())
        {

            List<Year> years = context.Years.ToList();
            List<Class> classes = context.Classes.ToList();
            var classYears = ClassYearFaker
                .GetClassYearFaker(classes,years)
                .Generate(10)
                .DistinctBy(x=>new {x.ClassId,x.YearId})
                .ToList();
            
            context.ClassYears.AddRange(classYears);

            context.SaveChanges();

        }
        


    }

}