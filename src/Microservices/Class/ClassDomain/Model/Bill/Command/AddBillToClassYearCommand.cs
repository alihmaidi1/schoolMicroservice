using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.Bill.Command;

public class AddBillToClassYearCommand:ICommand
{
    
    
    public Guid ClassYearId { get; set; }
    
    public  float Money { get; set; }
    
    public DateTime Date { get; set; }
    
    
}