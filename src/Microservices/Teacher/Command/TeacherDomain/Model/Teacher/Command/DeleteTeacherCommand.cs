using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Model.Teacher.Command;

public class DeleteTeacherCommand:ICommand
{
    
    public Guid Id { get; set; }
    
}