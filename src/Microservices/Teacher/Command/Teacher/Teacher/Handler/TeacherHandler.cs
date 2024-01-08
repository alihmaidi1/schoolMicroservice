using Common.OperationResult;
using Domain.Model.Teacher;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teacher.Repository.Teacher;

namespace Teacher.Teacher.Handler;

public class TeacherHandler:OperationResult,
    IRequestHandler<AddTeacherCommand, JsonResult>
{
    private ITeacherRepository TeacherRepository;
    public TeacherHandler(ITeacherRepository TeacherRepository)
    {

        this.TeacherRepository = TeacherRepository;


    }
    
    public async Task<JsonResult> Handle(AddTeacherCommand request, CancellationToken cancellationToken)
    {

        TeacherRepository.AddTeacher(request.Name, request.Email, request.Password);
        return Success("teacher was added successfully");
    }
    
    
}