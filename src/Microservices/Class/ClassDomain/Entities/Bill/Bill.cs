using ClassDomain.Entities.StageClass;
using Common.Entity.Entity;

namespace ClassDomain.Entities.Bill;

public class Bill:BaseEntity<BillID>
{

    public Bill()
    {
        Id = new BillID(Guid.NewGuid());
        StudentBills = new HashSet<StudentBill.StudentBill>();
        StudentClasses = new HashSet<StudentClass.StudentClass>();

    }
    
    public float Money { get; set; }
    
    
    public ICollection<StudentClass.StudentClass> StudentClasses { get; set; }
    
    public ICollection<StudentBill.StudentBill> StudentBills { get; set; }
    
    public DateTime Date { get; set; }
    
    
    
    public ClassYearID ClassYearId { get; set; }
    public ClassYear.ClassYear ClassYear { get; set; }
}