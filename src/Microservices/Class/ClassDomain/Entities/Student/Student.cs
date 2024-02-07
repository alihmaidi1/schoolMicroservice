using ClassDomain.Entities.Parent;
using Common.Entity.Entity;
using EntityFrameworkCore.EncryptColumn.Attribute;

namespace ClassDomain.Entities.Student;

public class Student:BaseEntity<StudentID>
{
    public Student()
    {

        Id = new StudentID(Guid.NewGuid());
        StudentClasses = new HashSet<StudentClass.StudentClass>();
        ClassYears = new HashSet<ClassYear.ClassYear>();
        

    }
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    
    [EncryptColumn]

    public string Password { get; set; }
    
    
    public ParentID ParentId { get; set; }
    public Parent.Parent Parent { get; set; }
    
    public ICollection<ClassYear.ClassYear> ClassYears { get; set; }
    
    public ICollection<StudentClass.StudentClass> StudentClasses { get; set; }
}