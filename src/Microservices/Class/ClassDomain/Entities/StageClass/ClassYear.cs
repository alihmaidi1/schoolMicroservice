using ClassDomain.Entities.Class;
using ClassDomain.Entities.Year;
using Common.Entity.Entity;

namespace ClassDomain.Entities.StageClass;

public class ClassYear:BaseEntity<ClassYearID>
{

    public ClassYear()
    {
        Id = new ClassYearID(Guid.NewGuid());
        Bills = new List<Bill.Bill>();

    }
    
    public YearID YearId { get; set; }
    
    public ClassID ClassId { get; set; }
    
    
    public Class.Class Class { get; set; }
    
    
    public Year.Year Year { get; set; }
    public ICollection<Bill.Bill>  Bills { get; set; }
    
}