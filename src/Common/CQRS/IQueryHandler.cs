using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Common.CQRS;

public interface IQueryHandler<TQuery>:IRequestHandler<TQuery,JsonResult> where TQuery :IQuery
{
    
}