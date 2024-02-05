using Common.CQRS;
using Common.Email;
using Common.OperationResult;
using Common.Rabbitmq.Events.Admin;
using Hangfire;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Model.Manager.Admin.Command;
using Repository.Manager.Admin;

namespace Admin.Manager.Admin.Command.Handler;

public class AdminCommandHandler:OperationResult,
    ICommandHandler<AddAdminCommand>,
    ICommandHandler<UpdateAdminCommand>,
    ICommandHandler<DeleteAdminCommand>


{

    private IMailService MailService;

    private IPublishEndpoint _publisher;
    private IAdminRepository AdminRepository;
    public AdminCommandHandler(IPublishEndpoint _publisher,IAdminRepository AdminRepository,IMailService MailService)
    {
        this._publisher = _publisher;
        this.AdminRepository = AdminRepository;
        this.MailService = MailService;

    }
    
    public  async Task<JsonResult> Handle(AddAdminCommand request, CancellationToken cancellationToken)
    {
        
        var id = Guid.NewGuid();
        BackgroundJob.Enqueue(() =>
        
           
            MailService.SendMail(request.Email, "new Admin In School",
            $"You Are New Manager In School and this is your password {request.Password}")
            
        );
        
         AdminRepository.Add(id,request.Email, request.Password, request.RoleId, request.Name);

         AddAdminEvent addAdminEvent = new AddAdminEvent()
         {
             Id = id,
             Name = request.Name
         };
         
         // await _publisher.Publish(addAdminEvent); 
         return Success("admin was added successfully");
        
    }

    public async Task<JsonResult> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
    {
        
        MailService.SendMail(request.Email, "update  Admin data In School",
            $"update Manager data In School and this is your password {request.Password}");
        AdminRepository.Update(request.AdminId,request.Email,request.Password,request.RoleId,request.Name);

        
        UpdateAdminEvent UpdateAdminEvent = new UpdateAdminEvent()
        {
            Id = request.AdminId,
            Name = request.Name
        };
        // await _publisher.Publish(UpdateAdminEvent);
        
        
        return Success("admin was updated successfully");

        
    }

    public async Task<JsonResult> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
    {
         AdminRepository.Delete(request.Id);
        return Success("Admin was Deleted Successfully");
    }
}