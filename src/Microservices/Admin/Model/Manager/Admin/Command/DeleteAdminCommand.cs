using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Admin.Command;

public class DeleteAdminCommand:IRequest<JsonResult>
{
    
    
    public Guid Id { get; set; }
    
}