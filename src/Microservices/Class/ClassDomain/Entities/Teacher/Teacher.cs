using Common.Entity.Entity;

namespace ClassDomain.Entities.Teacher;

public class Teacher:BaseEntity<TeacherID>
{

    public Teacher()
    {
        
        Id = new TeacherID(Guid.NewGuid());

        
    }
    
    public string Name { get; set; }
    public bool Status { get; set; }
}