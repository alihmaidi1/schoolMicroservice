using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Common.CQRS;

public interface ICommandHandler<TCommand>:IRequestHandler<TCommand,JsonResult> where TCommand :ICommand
{
    
}
