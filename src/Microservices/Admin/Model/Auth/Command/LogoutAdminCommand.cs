using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Auth.Command;

public class LogoutAdminCommand:IRequest<JsonResult>
{
    
}