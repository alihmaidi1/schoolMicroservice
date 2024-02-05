using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Password.Command;

public class ForgetPasswordCommand:ICommand
{
    
    
    public string Email { get; set; }

}