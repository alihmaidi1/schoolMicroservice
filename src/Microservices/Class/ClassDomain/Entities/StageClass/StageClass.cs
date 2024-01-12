using ClassDomain.Entities.Class;
using ClassDomain.Entities.Year;
using Common.Entity.Entity;

namespace ClassDomain.Entities.StageClass;

public class StageClass:BaseEntity<StageClassID>
{

    public StageClass()
    {

        Bills = new List<Bill.Bill>();

    }
    
    public YearID YearId { get; set; }
    
    public ClassID ClassId { get; set; }
    
    
    public ICollection<Bill.Bill>  Bills { get; set; }
    
}