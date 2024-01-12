using Common.Entity.Entity;

namespace ClassDomain.Entities.Parent;

public class Parent:BaseEntity<ParentID>
{

    public Parent()
    {

        Students = new HashSet<Student.Student>();
    }
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public ICollection<Student.Student> Students { get; set; }
}