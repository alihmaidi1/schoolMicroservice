using Common.CQRS;
using Domain.Entities.Manager.Role;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Role.Command;

public class UpdateRoleCommand:ICommand
{
    
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<string> Permissions { get; set; }

    
    
    
}