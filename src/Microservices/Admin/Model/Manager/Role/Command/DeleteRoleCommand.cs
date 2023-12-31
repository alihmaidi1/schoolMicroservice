using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Role.Command;

public class DeleteRoleCommand:IRequest<JsonResult>
{
    
    
    public Guid Id { get; set; }
    
}