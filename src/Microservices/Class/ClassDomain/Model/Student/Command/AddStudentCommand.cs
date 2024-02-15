using System.Text;
using Common.CQRS;

namespace ClassDomain.Model.Student.Command;

public class AddStudentCommand : ICommand
{
    
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    
    public string Password { get; set; }
    
    
    public Guid ParentId { get; set; }
    
}