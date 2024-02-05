using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Auth.Command;

public class LoginAdminCommand:ICommand
{

    
    public string Email { get; set; }

    public string Password { get; set; }

}