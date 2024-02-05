using System.Reflection.Metadata.Ecma335;
using Common.CQRS;
using Common.OperationResult;
using Domain.Model.Teacher.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teacher.Repository.Teacher;

namespace Teacher.Teacher.Command.Handler;

public class TeacherHandler:OperationResult,
    ICommandHandler<AddTeacherCommand>,
    ICommandHandler<UpdateTeacherCommand>,
    ICommandHandler<DeleteTeacherCommand>,
    ICommandHandler<ChangeTeacherStatusCommand>


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


    public async Task<JsonResult> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
    {
        TeacherRepository.UpdateTeacher(request.Id, request.Name, request.Email, request.Password);
        return Success("teacher updated successfully");
    }

    public async Task<JsonResult> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {
     
        TeacherRepository.Delete(request.Id);
        return Success("teacher was updated successfully");
    }

    public async Task<JsonResult> Handle(ChangeTeacherStatusCommand request, CancellationToken cancellationToken)
    {

        
        TeacherRepository.ChangeStatus(request.Id, request.Status);
        return Success("status was updated successfully");

    }
}