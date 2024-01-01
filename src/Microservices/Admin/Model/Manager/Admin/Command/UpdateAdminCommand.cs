using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Admin.Command;

public class UpdateAdminCommand:IRequest<JsonResult>
{
    
    
    public Guid AdminId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public Guid RoleId { get; set; }


    
}