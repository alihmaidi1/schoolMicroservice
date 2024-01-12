using ClassDomain.Entities.StageClass;
using Common.Entity.Entity;

namespace ClassDomain.Entities.Bill;

public class Bill:BaseEntity<BillID>
{
    
    public float Money { get; set; }
    
    public DateTime Date { get; set; }
    
    public StageClassID StageClassId { get; set; }
    public StageClass.StageClass StageClass { get; set; }
}