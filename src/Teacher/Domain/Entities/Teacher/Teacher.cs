using Common.Entity.Entity;

namespace Domain.Entities.Teacher;

public class Teacher:BaseEntity<TeacherID>
{

    public Teacher()
    {

        Id = new TeacherID(Guid.NewGuid());
    }
    
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public bool status { get; set; }
    
}