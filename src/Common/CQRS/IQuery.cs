using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Common.CQRS;

public interface IQuery:IRequest<JsonResult>
{
    
}