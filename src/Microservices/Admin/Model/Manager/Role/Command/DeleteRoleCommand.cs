using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Role.Command;

public class DeleteRoleCommand:ICommand
{
    
    
    public Guid Id { get; set; }
    
}