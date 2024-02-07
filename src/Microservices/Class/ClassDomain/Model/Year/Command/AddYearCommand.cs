using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.Year.Command;

public class AddYearCommand:ICommand
{
    
    public string Name { get; set; }
}