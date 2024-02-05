using ClassDomain.Entities.StageClass;
using Common.Entity.Entity;

namespace ClassDomain.Entities.Semester;

public class Semester:BaseEntity<SemesterID>
{


    public Semester()
    {

        Id = new SemesterID(Guid.NewGuid());
    }
    
    public string Name { get; set; }
    
    public ClassYear.ClassYear ClassYear { get; set; }
 
    public ClassYearID ClassYearId { get; set; }
}