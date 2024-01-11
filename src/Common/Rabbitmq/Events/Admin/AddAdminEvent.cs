namespace Common.Rabbitmq.Events.Admin;

public class AddAdminEvent
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
}