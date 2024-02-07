using ClassDomain.Entities.StageClass;
using Common.Entity.Entity;

namespace ClassDomain.Entities.Year;

public class Year:BaseEntity<YearID>
{

    public Year()
    {

        Id = new YearID(Guid.NewGuid());
        ClassYears = new HashSet<ClassYear.ClassYear>();

    }
    
    
    public string Name { get; set; }
    
    public ICollection<ClassYear.ClassYear> ClassYears { get; set; } 
    
}