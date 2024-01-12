using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Model.Warning.Command;

public class DeleteWarningCommand:IRequest<JsonResult>
{
    
    
    public Guid Id { get; set; }
    
}