using ClassDomain.Dto.ClassYear;
using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.ClassYear.Command;

public class UpdateClassYearCommand:ICommand
{
    
    
    public Guid Id { get; set; }
    
    public List<AddBilling> Billings { get; set; }
    
    
}