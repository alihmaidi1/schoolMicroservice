using Class.Repository.Year;
using ClassDomain.Entities.Year;
using ClassDomain.Model.Year.Command;
using Common.CQRS;
using Common.OperationResult;
using Common.Rabbitmq.Events.Year;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Class.Year.Command.Handler;

public class YearCommandHandler:OperationResult,
    ICommandHandler<AddYearCommand>,
    ICommandHandler<UpdateYearCommand>,
    ICommandHandler<DeleteYearCommand>

{
    private IPublishEndpoint _publisher;

    private IYearRepository YearRepository;
    public YearCommandHandler(IYearRepository YearRepository,IPublishEndpoint _publisher)
    {

        this._publisher = _publisher;
        this.YearRepository = YearRepository;

    }
    public async Task<JsonResult> Handle(AddYearCommand request, CancellationToken cancellationToken)
    {

        var id = Guid.NewGuid();
        await YearRepository.AddAsync(new ClassDomain.Entities.Year.Year()
        {
            Id = id,
            Name = request.Name
        });

        AddYearEvent addYearEvent = new AddYearEvent()
        {

            Id = id,
            Name = request.Name

        };

        await _publisher.Publish(addYearEvent);
        return Success(" year was added successfully");
    }

    public async Task<JsonResult> Handle(UpdateYearCommand request, CancellationToken cancellationToken)
    {
        await YearRepository.UpdateAsync(new ClassDomain.Entities.Year.Year()
        {

            Id = request.Id,
            Name = request.Name

        });
        UpdateYearEvent updateYearEvent = new UpdateYearEvent()
        {
            Id = request.Id,
            Name = request.Name

        };
        await _publisher.Publish(updateYearEvent);
        return Success("year was updated successfully");
    }

    public async Task<JsonResult> Handle(DeleteYearCommand request, CancellationToken cancellationToken)
    {

        YearRepository.Delete(request.Id);
        
        return Success("year was deleted successfully");
    }
}