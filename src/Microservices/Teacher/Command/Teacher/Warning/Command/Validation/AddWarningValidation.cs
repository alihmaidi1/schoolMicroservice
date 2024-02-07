using System.Security.Claims;
using Domain.Model.Warning.Command;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Teacher.Repository.Teacher;
using Teacher.Teacher.Command.Validation;
using Teacherinfrutructure;

namespace Teacher.Warning.Command.Validation;

public class AddWarningValidation:AbstractValidator<AddWarningCommand>
{


    public AddWarningValidation(ITeacherRepository teacherRepository,IHttpContextAccessor _httpContextAccessor,ApplicationDbContext dbContext)
    {


        RuleFor(x => x.Reson)
            .NotEmpty()
            .WithMessage("reson should be not empty")
            .NotNull()
            .WithMessage("reson should be not null");

        RuleFor(x=>x.TeacherID)
            .NotEmpty()
            .WithMessage("Teacher id should be not empty")
            .NotNull()
            .WithMessage("Teacher id should be not null")
            .Must(TeacherID=>teacherRepository.IsExists(TeacherID))
            .WithMessage("this teacher is not exists in our data");
        
        var ManagerID = _httpContextAccessor.HttpContext.User.Claims.Single(x=>x.Type==ClaimTypes.NameIdentifier).Value;


        RuleFor(x => ManagerID)

            .NotEmpty()
            .WithMessage("manager id should be not empty")
            .NotNull()
            .WithMessage("manager id should be not null")
            .Must(managerID=>dbContext.Managers.Any(x=>x.ManagerId==new Guid(managerID)))
            .WithMessage("this manager is not exists in our date");





    }
    
}