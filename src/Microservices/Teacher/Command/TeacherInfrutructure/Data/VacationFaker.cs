using Bogus;
using Domain.Entities.Manager;
using Domain.Entities.Teacher;
using Domain.Entities.Vacation;
using Domain.Entities.YearVacation;

namespace Teacherinfrutructure.Data;

public static class VacationFaker
{
    
    
    public static Faker<Vacation> GetVacationFaker(List<Year> years,List<Teacher> teachers,List<Manager> managers)
    {
        
        var Vacation= new Faker<Vacation>();

        Vacation.RuleFor(x => x.Reason, setter => setter.Random.Words(100));
        Vacation.RuleFor(x => x.YearId, setter => setter.PickRandom(years).Id);
        Vacation.RuleFor(x => x.TeacherId, setter => setter.PickRandom(teachers).Id);
        Vacation.RuleFor(x => x.ManagerId, setter => setter.PickRandom(managers).Id);
        
        return Vacation;
    }
    
}