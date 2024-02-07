using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Role.Command;

public class AddRoleCommand:ICommand
{
 
    public string Name { get; set; }
    
    public List<string> Permissions { get; set; }
    
    
}