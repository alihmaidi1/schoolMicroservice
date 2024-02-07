using Common.Rabbitmq.Events.Year;
using Domain.Repository.Year;
using MassTransit;

namespace Teacher.EventBusConsumer.Year;

public class AddYearConsumer:IConsumer<AddYearEvent>
{
    private IYearRepository yearRepository;
    public AddYearConsumer(IYearRepository yearRepository)
    {

        this.yearRepository = yearRepository;

    }
    public async Task Consume(ConsumeContext<AddYearEvent> context)
    {
        Domain.Entities.YearVacation.Year year = new Domain.Entities.YearVacation.Year()
        {

                Id = context.Message.Id,
                Name = context.Message.Name,
                

        };
        await yearRepository.AddAsync(year);
        
    }
}