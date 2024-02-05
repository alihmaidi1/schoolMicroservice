using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.Stage.Query;

public class GetStageQuery:IQuery
{
    
    public Guid Id { get; set; }
    
    
    
}