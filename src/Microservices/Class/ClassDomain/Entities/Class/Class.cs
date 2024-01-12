using ClassDomain.Entities.Stage;
using Common.Entity.Entity;

namespace ClassDomain.Entities.Class;

public class Class:BaseEntity<ClassID>
{

    public Class()
    {

        Id = new ClassID(Guid.NewGuid());
    }
    
    public string Name { get; set; }
    
    public StageID StageId { get; set; }
    
    public Stage.Stage Stage { get; set; }
    
    
}