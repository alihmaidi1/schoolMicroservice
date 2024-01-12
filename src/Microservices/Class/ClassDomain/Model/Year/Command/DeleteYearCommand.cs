using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.Year.Command;

public class DeleteYearCommand:IRequest<JsonResult>
{
    
    public Guid Id { get; set; }
    
}