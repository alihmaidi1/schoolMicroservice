using ClassDomain.Entities.Parent;
using Common.Entity.Entity;

namespace ClassDomain.Entities.Student;

public class Student:BaseEntity<StudentID>
{
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    public string Password { get; set; }
    
    public ParentID ParentId { get; set; }
    public Parent.Parent Parent { get; set; }
}