using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.Stage.Query;

public class GetStageQuery:IRequest<JsonResult>
{
    
    public Guid Id { get; set; }
    
    
    
}