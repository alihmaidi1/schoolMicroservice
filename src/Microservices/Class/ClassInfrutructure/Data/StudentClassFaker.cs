using Bogus;
using ClassDomain.Entities.ClassYear;
using ClassDomain.Entities.Student;
using ClassDomain.Entities.StudentClass;

namespace ClassInfrutructure.Data;

public static class StudentClassFaker
{
    public static Faker<StudentClass> GetStudentClassFaker(List<Student> students,List<ClassYear> classYears)
    {

        var studentClass = new Faker<StudentClass>();
        studentClass.RuleFor(x => x.ClassYearId, setter => setter.PickRandom(classYears).Id);
        studentClass.RuleFor(x => x.StudentId, setter => setter.PickRandom(students).Id);
        return studentClass;

    }

}