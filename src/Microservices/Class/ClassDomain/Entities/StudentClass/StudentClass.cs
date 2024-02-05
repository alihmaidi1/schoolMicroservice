using ClassDomain.Entities.StageClass;
using ClassDomain.Entities.Student;
using Common.Entity.Entity;

namespace ClassDomain.Entities.StudentClass;

public class StudentClass:BaseEntity<StudentClassID>
{
    
    public StudentID StudentId { get; set; }
    
    public Student.Student Student { get; set; }
    
    
    public ClassYearID ClassYearId { get; set; }
    public StageClass.ClassYear ClassYear { get; set; }
}