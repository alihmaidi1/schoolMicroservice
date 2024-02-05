using ClassDomain.Entities.Parent;
using ClassInfrutructure.Data;

namespace ClassInfrutructure.Seed;

public static class ParentSeeder
{

    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.Parents.Any())
        {

            List<Parent> parents = ParentFaker
                .GetParentFaker()
                .Generate(10)
                .DistinctBy(x=>new {x.Email})
                .ToList();
            context.Parents.AddRange(parents);
            context.SaveChanges();

        }
    }

}