using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Model.Warning.Command;

public class AddWarningCommand:ICommand
{
    
    public string Reson { get; set; }
    
    public Guid TeacherID { get; set; }
    
    
}