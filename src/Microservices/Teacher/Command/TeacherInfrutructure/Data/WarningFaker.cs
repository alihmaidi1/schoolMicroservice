using Bogus;
using Domain.Entities.Manager;
using Domain.Entities.Teacher;
using Domain.Entities.Warning;

namespace Teacherinfrutructure.Data;

public static class WarningFaker
{


    public static Faker<Warning> GetBrandFaker(List<Teacher> Teachers,List<Manager> managers)
    {


        var Warning= new Faker<Warning>();
        Warning.RuleFor(x => x.Reason, setter => setter.Random.Words(100));
        Warning.RuleFor(x => x.TeacherId,setter=>setter.PickRandom(Teachers).Id);
        Warning.RuleFor(x => x.ManagerId, setter => setter.PickRandom(managers).Id);
        return Warning;
    }

}