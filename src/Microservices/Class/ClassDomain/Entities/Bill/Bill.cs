using ClassDomain.Entities.StageClass;
using Common.Entity.Entity;

namespace ClassDomain.Entities.Bill;

public class Bill:BaseEntity<BillID>
{

    public Bill()
    {
        Id = new BillID(Guid.NewGuid());
        StudentBills = new HashSet<StudentBill.StudentBill>();

    }
    
    public float Money { get; set; }
    
    
    public ICollection<StudentBill.StudentBill> StudentBills { get; set; }
    
    public DateTime Date { get; set; }
    
    public ClassYearID ClassYearId { get; set; }
    public StageClass.ClassYear ClassYear { get; set; }
}