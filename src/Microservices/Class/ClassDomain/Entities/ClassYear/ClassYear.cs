using System.Collections;
using ClassDomain.Entities.Class;
using ClassDomain.Entities.StageClass;
using ClassDomain.Entities.Year;
using Common.Entity.Entity;

namespace ClassDomain.Entities.ClassYear;

public class ClassYear:BaseEntity<ClassYearID>
{

    public ClassYear()
    {
        Id = new ClassYearID(Guid.NewGuid());
        Bills = new HashSet<Bill.Bill>();

        Semesters = new HashSet<Semester.Semester>();
        Students = new HashSet<Student.Student>();
        StudentClasses = new HashSet<StudentClass.StudentClass>();

    }
    
    public YearID YearId { get; set; }
    
    public ClassID ClassId { get; set; }
    
    
    public Class.Class Class { get; set; }
    
    
    public Year.Year Year { get; set; }
    public ICollection<Bill.Bill>  Bills { get; set; }
    
    public ICollection<Semester.Semester> Semesters { get; set; } 
    
    public ICollection<StudentClass.StudentClass> StudentClasses { get; set; }
    
    public ICollection<Student.Student> Students { get; set; }
    
}