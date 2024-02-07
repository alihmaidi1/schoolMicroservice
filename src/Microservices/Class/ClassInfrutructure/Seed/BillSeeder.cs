using ClassDomain.Entities.ClassYear;
using ClassDomain.Entities.StageClass;
using ClassInfrutructure.Data;

namespace ClassInfrutructure.Seed;

public static class BillSeeder
{


    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.Bills.Any())
        {

            List<ClassYear> classYears = context.ClassYears.ToList();

            var Bills = BillFaker
                .GetBillFaker(classYears)
                .Generate(100)
                .DistinctBy(x => new { x.ClassYearId, x.Date })
                .ToList();

            context.Bills.AddRange(Bills);
            context.SaveChanges();

        }

    }

}