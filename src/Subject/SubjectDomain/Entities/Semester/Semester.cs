using Common.Entity.Entity;

namespace SubjectDomain.Entities.Semester;

public class Semester:BaseEntity<SemesterID>
{

    public Semester()
    {

        Id = new SemesterID(Guid.NewGuid());
        
    }
    
}