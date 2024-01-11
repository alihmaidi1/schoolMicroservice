using Common.Rabbitmq.Events.Admin;
using Domain.Entities.Manager;
using Domain.Repository;
using MassTransit;

namespace Teacher.EventBusConsumer.Admin;

public class AddAdminConsumer:IConsumer<AddAdminEvent>
{
    private IManagerRepository ManagerRepository;
    public AddAdminConsumer(IManagerRepository ManagerRepository)
    {

        this.ManagerRepository = ManagerRepository;

    }
    
    public async Task Consume(ConsumeContext<AddAdminEvent> context)
    {

        var Manager = new Manager()
        {
            Id = context.Message.Id,
            Name = context.Message.Name

        };
        await ManagerRepository.AddAsync(Manager);
        
        
    }
}