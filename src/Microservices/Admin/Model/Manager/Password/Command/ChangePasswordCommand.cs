using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Password.Command;

public class ChangePasswordCommand:ICommand
{
    
    
    public string Password { get; set; }
    
}