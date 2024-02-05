using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.Year.Command;

public class DeleteYearCommand:ICommand
{
    
    public Guid Id { get; set; }
    
}