using Class.Repository.Year;
using ClassDomain.Entities.Year;
using ClassDomain.Model.Year.Command;
using Common.CQRS;
using Common.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Class.Year.Command.Handler;

public class YearCommandHandler:OperationResult,
    ICommandHandler<AddYearCommand>,
    ICommandHandler<UpdateYearCommand>,
    ICommandHandler<DeleteYearCommand>

{
    private IYearRepository YearRepository;
    public YearCommandHandler(IYearRepository YearRepository)
    {

        this.YearRepository = YearRepository;

    }
    public async Task<JsonResult> Handle(AddYearCommand request, CancellationToken cancellationToken)
    {

        await YearRepository.AddAsync(new ClassDomain.Entities.Year.Year()
        {

            Name = request.Name
        });
        return Success(" year was added successfully");
    }

    public async Task<JsonResult> Handle(UpdateYearCommand request, CancellationToken cancellationToken)
    {
        await YearRepository.UpdateAsync(new ClassDomain.Entities.Year.Year()
        {

            Id = request.Id,
            Name = request.Name

        });
        return Success("year was updated successfully");
    }

    public async Task<JsonResult> Handle(DeleteYearCommand request, CancellationToken cancellationToken)
    {

        // YearRepository.Delete(request.Id);
        await YearRepository.DeleteAsync(new ClassDomain.Entities.Year.Year()
        {
        
            Id = new YearID(request.Id)
        
        });
        
        return Success("year was deleted successfully");
    }
}