using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.Bill.Command;

public class DeleteBillCommand:ICommand
{
    
    
    public Guid Id { get; set; }
}