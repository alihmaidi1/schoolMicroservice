using Bogus;
using ClassDomain.Entities.Parent;
using ClassDomain.Entities.Student;

namespace ClassInfrutructure.Data;

public static class StudentFaker
{

    public static Faker<Student> GetStudentFaker(List<Parent> parents)
    {

        var student = new Faker<Student>();
        student.RuleFor(x => x.Name, setter => setter.Random.Word());
        student.RuleFor(x => x.Email, setter => setter.Internet.Email());
        student.RuleFor(x => x.Password, setter => "12345678");
        student.RuleFor(x => x.ParentId, setter => setter.PickRandom(parents).Id);
        student.RuleFor(x => x.Number,setter=>setter.Random.Int(1000,9999));
        student.RuleFor(x => x.Gender, setter => setter.Random.Bool());
        return student;
    }
}