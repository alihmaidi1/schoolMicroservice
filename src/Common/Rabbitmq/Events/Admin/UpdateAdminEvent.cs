namespace Common.Rabbitmq.Events.Admin;

public class UpdateAdminEvent
{
    
    public Guid Id { get; set; }
    
    public string Name { get; set; }
}