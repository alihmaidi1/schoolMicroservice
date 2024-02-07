using Microsoft.Extensions.DependencyInjection;
using ApplicationDbContext = Infrutructure.ApplicationDbContext;

namespace Teacherinfrutructure.Seed;

public static class DatabaseSeed
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var transaction = context.Database.BeginTransaction();

        try
        {
            
            await SuperAdminSeed.seedData(context);
            await YearSeeder.seedData(context);
            await TeacherSeeder.seedData(context);
            await WarningSeeder.seedData(context);
            await VacationSeeder.seedData(context);
            await transaction.CommitAsync();

        }
        catch(Exception ex) 

        {

            transaction.Rollback();
            throw new Exception(ex.Message);
        }


    }

    
}