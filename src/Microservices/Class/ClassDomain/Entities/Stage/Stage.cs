using Common.Entity.Entity;

namespace ClassDomain.Entities.Stage;

public class Stage:BaseEntity<StageID>
{

    public Stage()
    {
        Id = new StageID(Guid.NewGuid());
        Classes = new HashSet<Class.Class>();

    }
    public string Name { get; set; }
    
    public ICollection<Class.Class> Classes { get; set; }
    
}