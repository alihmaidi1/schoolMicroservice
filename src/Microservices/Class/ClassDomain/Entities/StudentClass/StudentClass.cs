using System.Collections;
using ClassDomain.Entities.StageClass;
using ClassDomain.Entities.Student;
using Common.Entity.Entity;

namespace ClassDomain.Entities.StudentClass;

public class StudentClass:BaseEntity<StudentClassID>
{

    public StudentClass()
    {

        Id = new StudentClassID(Guid.NewGuid());
        Bills = new HashSet<Bill.Bill>();
        StudentBills = new HashSet<StudentBill.StudentBill>();

    }
    public StudentID StudentId { get; set; }
    
    public Student.Student Student { get; set; }
    
    
    public ClassYearID ClassYearId { get; set; }
    public ClassYear.ClassYear ClassYear { get; set; }
    
    public ICollection<StudentBill.StudentBill> StudentBills { get; set; }
    
    public ICollection<Bill.Bill> Bills { get; set; }
}