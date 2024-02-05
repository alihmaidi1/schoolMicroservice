using Common.Entity.Entity;

namespace ClassDomain.Entities.Semester;

public class Semester:BaseEntity<SemesterID>
{


    public Semester()
    {

        Id = new SemesterID(Guid.NewGuid());
    }
    
    public string Name { get; set; }
    
    
}