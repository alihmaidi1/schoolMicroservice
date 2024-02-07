using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Manager.Password.Command;

public class CheckCodeCommand:ICommand
{
    
    
    public string Code { get; set; }

}