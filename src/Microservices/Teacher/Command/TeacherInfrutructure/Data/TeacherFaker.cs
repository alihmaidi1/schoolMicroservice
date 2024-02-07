using Bogus;
using Domain.Entities.Teacher;

namespace Teacherinfrutructure.Data;

public static class TeacherFaker
{

    public static Faker<Teacher> GetBrandFaker()
    {

        var Teacher = new Faker<Teacher>();

        Teacher.RuleFor(x=>x.Name,setter=>setter.Name.FindName());

        Teacher.RuleFor(x => x.Email, setter => setter.Internet.Email());
        Teacher.RuleFor(x => x.Password, "12345678");
        Teacher.RuleFor(x => x.status, setter => setter.Random.Bool());
        
        
        return Teacher;
    }
}