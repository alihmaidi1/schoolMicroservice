namespace Dto.Manager.Admin;

public class GetAllAdmin
{
    
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public string Email { get; set; }
    
    public DateTime CreatedAt { get; set; }
}