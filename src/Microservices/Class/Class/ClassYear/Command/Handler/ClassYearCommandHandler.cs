using Class.Repository.ClassYear;
using ClassDomain.Entities.Bill;
using ClassDomain.Entities.StageClass;
using ClassDomain.Model.ClassYear.Command;
using Common.CQRS;
using Common.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Class.ClassYear.Command.Handler;

public class ClassYearCommandHandler:OperationResult,
    
    ICommandHandler<AddClassYearCommand>,
    ICommandHandler<DeleteClassYearCommand>
// IRequestHandler<UpdateClassYearCommand, JsonResult>

{
    private IClassYearRepository ClassYearRepository;
    public ClassYearCommandHandler(IClassYearRepository ClassYearRepository)
    {


        this.ClassYearRepository = ClassYearRepository;



    }
    
    
    public async Task<JsonResult> Handle(AddClassYearCommand request, CancellationToken cancellationToken)
    {
        ClassDomain.Entities.StageClass.ClassYear classYear = new ClassDomain.Entities.StageClass.ClassYear()
        {

            YearId = request.YearID,
            ClassId = request.ClassID,
            Bills = request.Billings.Select(x=>new ClassDomain.Entities.Bill.Bill()
            {
                Date = x.Date,
                Money = x.Money
                
            }).ToList()
        };
        await ClassYearRepository.AddAsync(classYear);
        
        
        return Success("New Year Was Added To This Class Successfully");

    }

    // public async Task<JsonResult> Handle(UpdateClassYearCommand request, CancellationToken cancellationToken)
    // {
    //
    //
    //
    //     ClassYearRepository.Update(request.Id, request.Billings.Select(x => new Bill()
    //     {
    //         Money = x.Money,
    //         Date = x.Date,
    //         ClassYearId = request.Id
    //
    //     }).ToList());
    //     
    //      return Success("Year class was updated successfully");
    // }
    
    public async Task<JsonResult> Handle(DeleteClassYearCommand request, CancellationToken cancellationToken)
    {
        
        ClassDomain.Entities.StageClass.ClassYear classYear = new ClassDomain.Entities.StageClass.ClassYear()
        {

            Id = request.Id

        };
        await ClassYearRepository.DeleteAsync(classYear);
        return Success("class year was deleted successfully");
    }
    
    
}