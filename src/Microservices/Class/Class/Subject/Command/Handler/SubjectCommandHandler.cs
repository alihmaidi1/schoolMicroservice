using Class.Repository.Subject;
using ClassDomain.Model.Subject.Command;
using Common.CQRS;
using Common.OperationResult;
using Microsoft.AspNetCore.Mvc;

namespace Class.Subject.Command.Handler;

public class SubjectCommandHandler:OperationResult,
    ICommandHandler<AddSubjectCommand>,
    ICommandHandler<UpdateSubjectCommand>,
    ICommandHandler<DeleteSubjectCommand>

{
    private ISubjectRepository SubjectRepository;
    public SubjectCommandHandler(ISubjectRepository SubjectRepository)
    {

        this.SubjectRepository = SubjectRepository;

    }
    
    public async Task<JsonResult> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
    {

        ClassDomain.Entities.Subject.Subject subject = new ClassDomain.Entities.Subject.Subject()
        {

            Name = request.Name
        };

        await SubjectRepository.AddAsync(subject);
        return Success("This Subject was added successfully");
    }

    public async Task<JsonResult> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
    {
        
        ClassDomain.Entities.Subject.Subject subject = new ClassDomain.Entities.Subject.Subject()
        {

            Id = request.Id
        };

        await SubjectRepository.DeleteAsync(subject);
        return Success("This Subject was deleted successfully");
        
        
    }

    public async Task<JsonResult> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
    {
        ClassDomain.Entities.Subject.Subject subject = new ClassDomain.Entities.Subject.Subject()
        {

            Id = request.Id,
            Name = request.Name
        };

        await SubjectRepository.UpdateAsync(subject);
        return Success("This Subject was updated  successfully");
    }
}