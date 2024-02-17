using Common.Entity.Entity;

namespace SubjectDomain.Entities.Subject;

public class Subject:BaseEntity<SubjectID>
{

    public Subject()
    {

        Id = new SubjectID(Guid.NewGuid());

    }
    
    public string Name { get; set; }
    
    
}