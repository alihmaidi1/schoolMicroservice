using ClassDomain.Entities.StageClass;
using ClassDomain.Entities.StudentBill;
using Microsoft.Extensions.DependencyInjection;

namespace ClassInfrutructure.Seed;

public static class ClassDatabasebSeed
{
    
    public static async Task InitializeAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var transaction = context.Database.BeginTransaction();

        try
        {


            await StageSeeder.seedData(context);
            await YearSeeder.seedData(context);
            await ClassYearSeeder.seedData(context);
            await BillSeeder.seedData(context);
            await SemesterSeeder.seedData(context);
            await ParentSeeder.seedData(context);
            await StudentSeeder.seedData(context);
            await StudentClassSeeder.seedData(context);
            await StudentBillSeeder.seedData(context);
            await transaction.CommitAsync();

            


        }
        catch(Exception ex) 

        {

            transaction.Rollback();
            throw new Exception(ex.Message);
        }


    }

}