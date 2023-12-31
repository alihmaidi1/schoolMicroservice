namespace Dto.Manager.Role;

public class GetAllRole
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public List<string> Permissions {get; set; }
    
    public DateTime CreatedAt { get; set; }
    
}