using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Admin.Command;

public class AddAdminCommand:ICommand
{
 
    public string Name { get; set; }
    
    public string Email { get; set; }
    public string Password { get; set; }
    
    public Guid RoleId { get; set; }
    
    
}