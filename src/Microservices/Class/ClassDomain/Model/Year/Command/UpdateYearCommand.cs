using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.Year.Command;

public class UpdateYearCommand:ICommand
{
    
    public Guid Id { get; set; }
    
    public string Name { get; set; }
}