using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Common.CQRS;

public interface ICommand:IRequest<JsonResult>
{
    
}
//
//
// public interface ICommand<TResponse> : IRequest<JsonResult>
// {
//     
//     
// }