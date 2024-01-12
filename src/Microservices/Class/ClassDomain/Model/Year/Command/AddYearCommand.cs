using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.Year.Command;

public class AddYearCommand:IRequest<JsonResult>
{
    
    public string Name { get; set; }
}