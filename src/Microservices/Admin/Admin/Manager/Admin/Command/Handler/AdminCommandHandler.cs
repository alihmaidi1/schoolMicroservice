using Common.Email;
using Common.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Model.Manager.Admin.Command;
using Repository.Manager.Admin;

namespace Admin.Manager.Admin.Command.Handler;

public class AdminCommandHandler:OperationResult,
    IRequestHandler<AddAdminCommand, JsonResult>,
    IRequestHandler<UpdateAdminCommand, JsonResult>,
    IRequestHandler<DeleteAdminCommand, JsonResult>


{

    private IMailService MailService;

    private IAdminRepository AdminRepository;
    public AdminCommandHandler(IAdminRepository AdminRepository,IMailService MailService)
    {
        this.AdminRepository = AdminRepository;
        this.MailService = MailService;

    }
    
    public  async Task<JsonResult> Handle(AddAdminCommand request, CancellationToken cancellationToken)
    {


         MailService.SendMail(request.Email, "new Admin In School",
            $"You Are New Manager In School and this is your password {request.Password}");
         AdminRepository.Add(request.Email, request.Password, request.RoleId, request.Name);
         return Success("admin was added successfully");
        
    }

    public async Task<JsonResult> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
    {
        
        MailService.SendMail(request.Email, "update  Admin data In School",
            $"update Manager data In School and this is your password {request.Password}");
        AdminRepository.Update(request.AdminId,request.Email,request.Password,request.RoleId,request.Name);
        return Success("admin was updated successfully");

        
    }

    public async Task<JsonResult> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
    {
        await AdminRepository.DeleteAsync(new Domain.Entities.Manager.Admin.Admin()
        {
            Id = request.Id
        });
        
        return Success("Admin was Deleted Successfully");
    }
}