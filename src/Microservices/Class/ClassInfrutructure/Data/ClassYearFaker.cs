using Bogus;
using ClassDomain.Entities.Class;
using ClassDomain.Entities.ClassYear;
using ClassDomain.Entities.StageClass;
using ClassDomain.Entities.Year;

namespace ClassInfrutructure.Data;

public static class ClassYearFaker
{
    public static Faker<ClassYear> GetClassYearFaker(List<Class> classes,List<Year> years)
    {

        var ClassYear = new Faker<ClassYear>();
        ClassYear.RuleFor(x => x.ClassId, setter => setter.PickRandom(classes).Id);
        ClassYear.RuleFor(x=>x.YearId,setter=>setter.PickRandom(years).Id);
        return ClassYear;


    }

}