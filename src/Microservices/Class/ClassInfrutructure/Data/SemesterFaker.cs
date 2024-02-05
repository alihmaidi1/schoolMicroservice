using Bogus;
using ClassDomain.Entities.ClassYear;
using ClassDomain.Entities.Semester;

namespace ClassInfrutructure.Data;

public static class SemesterFaker
{
    public static Faker<Semester> GetSemesterFaker(List<ClassYear> classYears)
    {

        var semester = new Faker<Semester>();
        semester.RuleFor(x => x.Name, setter => setter.Random.Word());
        semester.RuleFor(x => x.ClassYearId, setter => setter.PickRandom(classYears).Id);
        
        return semester;
    }

}