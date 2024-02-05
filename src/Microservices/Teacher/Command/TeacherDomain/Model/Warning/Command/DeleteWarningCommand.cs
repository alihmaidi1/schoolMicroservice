using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Model.Warning.Command;

public class DeleteWarningCommand:ICommand
{
    
    
    public Guid Id { get; set; }
    
}