using ClassDomain.Entities.Stage;
using ClassDomain.Entities.StageClass;
using Common.Entity.Entity;

namespace ClassDomain.Entities.Class;

public class Class:BaseEntity<ClassID>
{

    public Class()
    {

        Id = new ClassID(Guid.NewGuid());
        ClassYears = new HashSet<ClassYear.ClassYear>();
    }
    
    public string Name { get; set; }
    
    public StageID StageId { get; set; }
    
    public Stage.Stage Stage { get; set; }
    
    
    public ICollection<ClassYear.ClassYear > ClassYears { get; set; }
    
}