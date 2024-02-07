using ClassDomain.Dto.ClassYear;
using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassDomain.Model.ClassYear.Command;

public class AddClassYearCommand:ICommand
{
    
    
    public Guid YearID { get; set; }
    
    public Guid ClassID { get; set; }
    
    public List<AddBilling> Billings { get; set; }
    
    
}