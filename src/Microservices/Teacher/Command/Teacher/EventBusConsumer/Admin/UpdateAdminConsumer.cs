using Common.Rabbitmq.Events.Admin;
using Domain.Entities.Manager;
using Domain.Repository;
using MassTransit;

namespace Teacher.EventBusConsumer.Admin;

public class UpdateAdminConsumer:IConsumer<UpdateAdminEvent>
{
    
    private IManagerRepository ManagerRepository;
    public UpdateAdminConsumer(IManagerRepository ManagerRepository)
    {

        this.ManagerRepository = ManagerRepository;

    }

    public async Task Consume(ConsumeContext<UpdateAdminEvent> context)
    {
        
        var Manager = new Manager()
        {
            
            ManagerId = context.Message.Id,
            Name = context.Message.Name
        };
        await ManagerRepository.UpdateAsync(Manager);
    }
}