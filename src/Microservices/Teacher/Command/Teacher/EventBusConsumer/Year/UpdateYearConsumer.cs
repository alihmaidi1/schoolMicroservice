using Common.Rabbitmq.Events.Year;
using Domain.Repository.Year;
using MassTransit;

namespace Teacher.EventBusConsumer.Year;

public class UpdateYearConsumer:IConsumer<UpdateYearEvent>
{
    private IYearRepository YearRepository;
    public UpdateYearConsumer(IYearRepository YearRepository)
    {

        this.YearRepository = YearRepository;

    }
    public async Task Consume(ConsumeContext<UpdateYearEvent> context)
    {

        await YearRepository.UpdateAsync(new Domain.Entities.YearVacation.Year()
        {

            Id = context.Message.Id,
            Name = context.Message.Name

        });
        
    }
}