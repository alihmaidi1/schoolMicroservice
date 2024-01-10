using Org.BouncyCastle.Crypto.Engines;

namespace Domain.Dto.Teacher;

public class GetAllTeacher
{
    
    
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    public string Name { get; set; }
}