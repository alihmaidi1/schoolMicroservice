using Common.CQRS;
using Common.OperationResult;
using Domain.Model.Vacation.Command;
using Domain.Repository.Vacation;
using Microsoft.AspNetCore.Mvc;

namespace Teacher.Vacation.Command.Handler;

public class VacationCommandHandler:OperationResult,
    ICommandHandler<AddVacationCommand>,
    ICommandHandler<ChangeVacationCommand>,
    ICommandHandler<DeleteVacationCommand>,
    ICommandHandler<CancelVacationCommand>



{
    private IVacationRepository VacationRepository;
    public VacationCommandHandler(IVacationRepository VacationRepository)
    {

        this.VacationRepository = VacationRepository;

    }
    public async Task<JsonResult> Handle(AddVacationCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Vacation.Vacation vacation = new Domain.Entities.Vacation.Vacation()
        {

            Reason = request.Reason,
            TeacherId = request.TeacherId,
            YearId = request.YearId

        };

        await VacationRepository.AddAsync(vacation);

        // send brodcast notification to admins
        
        return Success("the vacation was ordered successfully please wait for admin accept");


    }

    public async Task<JsonResult> Handle(ChangeVacationCommand request, CancellationToken cancellationToken)
    {
        VacationRepository.ChangeVacationStatus(request.Id, request.Status);

        // send notification to teacher about this vacation status
        return Success("vacation status was updated successfully");
    }

    
    public async Task<JsonResult> Handle(DeleteVacationCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Vacation.Vacation vacation = new Domain.Entities.Vacation.Vacation()
        {
            Id = request.Id

        };

        await VacationRepository.DeleteAsync(vacation);
        return Success("vacation was deleted successfully");
        
    }

    public async Task<JsonResult> Handle(CancelVacationCommand request, CancellationToken cancellationToken)
    {
        
        Domain.Entities.Vacation.Vacation vacation = new Domain.Entities.Vacation.Vacation()
        {
            Id = request.Id

        };
        await VacationRepository.DeleteAsync(vacation);
        return Success("vacation was canceled successfully");

    }
}