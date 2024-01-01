using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Admin.Command;

public class AddAdminCommand:IRequest<JsonResult>
{
 
    public string Name { get; set; }
    
    public string Email { get; set; }
    public string Password { get; set; }
    
    public Guid RoleId { get; set; }
    
    
}