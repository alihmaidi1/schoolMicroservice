using Class.Repository.Parent;
using ClassDomain.Model.Parent.Command;
using Common.CQRS;
using Common.OperationResult;
using Microsoft.AspNetCore.Mvc;

namespace Class.Parent.Command.Handler;

public class ParentCommandHandler:OperationResult,
    ICommandHandler<AddParentCommand>,
    ICommandHandler<UpdateParentCommand>,
    ICommandHandler<UpdateParentPasswordCommand>,
    ICommandHandler<DeleteParentCommand>


{
    private IParentRepository ParentRepository;
    public ParentCommandHandler(IParentRepository ParentRepository)
    {

        this.ParentRepository = ParentRepository;

    }
    
    public async Task<JsonResult> Handle(AddParentCommand request, CancellationToken cancellationToken)
    {

        await ParentRepository.AddAsync(new ClassDomain.Entities.Parent.Parent()
        {

            Name = request.Name,
            Email=request.Email,
            Password = request.Password

        });
        
        return Success("parent was added successfully into our database");
    }

    public async Task<JsonResult> Handle(UpdateParentCommand request, CancellationToken cancellationToken)
    {

        ParentRepository.Update(request.Id, request.Name, request.Email);
        return Success("parent data was updated successfully");
        
    }

    public async Task<JsonResult> Handle(UpdateParentPasswordCommand request, CancellationToken cancellationToken)
    {

        ParentRepository.UpdatePassword(request.Id,request.Password);
        return Success("parent password was updated successfullly");
    }

    public async Task<JsonResult> Handle(DeleteParentCommand request, CancellationToken cancellationToken)
    {
        ParentRepository.Delete(request.Id);
        return Success("this parent was deleted successfully");
    }
}