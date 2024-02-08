using ClassDomain.Dto.Student;

namespace ClassDomain.Dto.Parent;

public class GetParentResponse
{
    
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public string Email { get; set; }
    public List<GetStudentClassResponse> Students { get; set; } 

    
}