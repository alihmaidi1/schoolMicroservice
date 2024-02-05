using Domain.Entities.Manager;
using Domain.Entities.Teacher;
using Domain.Entities.Vacation;
using Domain.Entities.YearVacation;
using Teacherinfrutructure.Data;

namespace Teacherinfrutructure.Seed;

public static class VacationSeeder
{
    public static async Task seedData(ApplicationDbContext context)
    {


        if (!context.Vacations.Any())
        {

            List<Teacher> teachers = context.Teachers.ToList();
            List<Year> years = context.Year.ToList();
            List<Manager> managers = context.Managers.ToList();
            List<Vacation> vacations = VacationFaker.GetVacationFaker(years,teachers,managers).Generate(10);
            context.AddRange(vacations);
            context.SaveChanges();
        }


    }
    
}