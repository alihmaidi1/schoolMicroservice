namespace Common.Rabbitmq.Events.Year;

public class AddYearEvent
{
    
    public Guid Id { get; set; }
    
    public string Name { get; set; }
}