using Class.Repository.Semester;
using ClassDomain.Model.Semester.Command;
using Common.CQRS;
using Common.OperationResult;
using Microsoft.AspNetCore.Mvc;

namespace Class.Semester.Command.Handler;

public class SemesterCommandHandler:OperationResult,
    ICommandHandler<AddSemesterCommand>,
    ICommandHandler<DeleteSemesterCommand>

{
    private ISemesterRepository SemesterRepository;
    public SemesterCommandHandler(ISemesterRepository SemesterRepository)
    {

        this.SemesterRepository = SemesterRepository;

    }
    
    
    public async Task<JsonResult> Handle(AddSemesterCommand request, CancellationToken cancellationToken)
    {

        SemesterRepository.AddAsync(new ClassDomain.Entities.Semester.Semester()
        {

            Name = request.Name,
            ClassYearId = request.ClassYearId

        });
        return Success("semester was added successfully to this class year");
    }

    public async Task<JsonResult> Handle(DeleteSemesterCommand request, CancellationToken cancellationToken)
    {
        SemesterRepository.Delete(request.Id);
        return Success("semester was deleted successfully");
    }
}