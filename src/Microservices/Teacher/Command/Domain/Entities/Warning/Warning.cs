using Common.Entity.Entity;
using Domain.Entities.Manager;
using Domain.Entities.Teacher;

namespace Domain.Entities.Warning;

public class Warning:BaseEntity<WarningID>
{

    public Warning()
    {
        
        Id = new WarningID(Guid.NewGuid());
    }
    
    public string Reason { get; set; }

    
    
    public ManagerID ManagerId { get; set; }
    public Manager.Manager Manager { get; set; }
    
    
    
    public TeacherID TeacherId { get; set; }
    public Teacher.Teacher Teacher { get; set; }
    
    
}