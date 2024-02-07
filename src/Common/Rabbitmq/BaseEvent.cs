namespace Common.Rabbitmq;

public class BaseEvent
{
    
    public Guid Id { get; private set; }
    public DateTime CreationDate { get; private set; }


    public BaseEvent( Guid Id ,DateTime creationDate)
    {

        
        this.Id = Id;
        this.CreationDate = creationDate;

    }


    public BaseEvent()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }
    
    
}