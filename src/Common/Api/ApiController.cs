using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Api;

public class ApiController:ControllerBase
{
    
    private IMediator mediatorinstance;
    protected  IMediator Mediator=> mediatorinstance??=HttpContext.RequestServices.GetService<IMediator>();

    
}