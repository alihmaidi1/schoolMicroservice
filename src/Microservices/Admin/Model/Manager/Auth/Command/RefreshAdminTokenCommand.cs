using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Auth.Command;

public class RefreshAdminTokenCommand:ICommand
{
    
    
    public string RefreshToken { get; set; }

}