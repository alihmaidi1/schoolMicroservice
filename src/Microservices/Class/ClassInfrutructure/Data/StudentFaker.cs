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
        student.RuleFor(x => x.Password, setter => setter.Internet.Password());
        student.RuleFor(x => x.ParentId, setter => setter.PickRandom(parents).Id);
        return student;
    }
}