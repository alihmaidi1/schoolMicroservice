using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.ClassYear.Command;

public class DeleteClassYearCommand:ICommand
{
    
    
    public Guid Id { get; set; }
    
}