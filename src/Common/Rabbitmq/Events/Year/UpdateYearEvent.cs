namespace Common.Rabbitmq.Events.Year;

public class UpdateYearEvent
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}