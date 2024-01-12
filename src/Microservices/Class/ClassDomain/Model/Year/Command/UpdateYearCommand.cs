using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.Year.Command;

public class UpdateYearCommand:IRequest<JsonResult>
{
    
    public Guid Id { get; set; }
    
    public string Name { get; set; }
}