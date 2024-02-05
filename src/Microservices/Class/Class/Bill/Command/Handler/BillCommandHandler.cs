using Class.Repository.Bill;
using ClassDomain.Model.Bill.Command;
using Common.CQRS;
using Common.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Class.Bill.Command.Handler;

public class BillCommandHandler:OperationResult,
    ICommandHandler<AddBillToClassYearCommand>,
    ICommandHandler<UpdatebillCommand>,
    ICommandHandler<DeleteBillCommand>


{
    private IBillRepository BillRepository;
    public BillCommandHandler(IBillRepository BillRepository)
    {

        this.BillRepository = BillRepository;

    }
    
    
    public async Task<JsonResult> Handle(AddBillToClassYearCommand request, CancellationToken cancellationToken)
    {

        ClassDomain.Entities.Bill.Bill bill = new ClassDomain.Entities.Bill.Bill()
        {

            ClassYearId = request.ClassYearId,
            Money = request.Money,
            Date = request.Date

        };
        await BillRepository.AddAsync(bill);
        return Success("bill was added successfully");
    }

    public async Task<JsonResult> Handle(UpdatebillCommand request, CancellationToken cancellationToken)
    {
        
        
        
        ClassDomain.Entities.Bill.Bill bill = new ClassDomain.Entities.Bill.Bill()
        {

            Id = request.Id,
            Money = request.Money,
            Date = request.Date

        };
        await BillRepository.UpdateAsync(bill);
        return Success("bill was updated successfully");
        
    }

    public async Task<JsonResult> Handle(DeleteBillCommand request, CancellationToken cancellationToken)
    {
        BillRepository.Delete(request.Id);
        return Success("bill was deleted successfully");



    }
}