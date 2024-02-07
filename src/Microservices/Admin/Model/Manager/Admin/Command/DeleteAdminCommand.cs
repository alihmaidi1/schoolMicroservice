using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Admin.Command;

public class DeleteAdminCommand:ICommand
{
    
    
    public Guid Id { get; set; }
    
}