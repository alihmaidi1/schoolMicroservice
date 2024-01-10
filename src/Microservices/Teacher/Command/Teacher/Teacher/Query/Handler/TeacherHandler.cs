using Common.OperationResult;
using Domain.Model.Teacher.Command;
using Domain.Model.Teacher.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teacher.Repository.Teacher;

namespace Teacher.Teacher.Query.Handler;

public class TeacherHandler:OperationResult,
    IRequestHandler<GetAllTeacher, JsonResult>
{
    private ITeacherRepository TeacherRepository;

    public TeacherHandler(ITeacherRepository TeacherRepository)
    {

        this.TeacherRepository = TeacherRepository;

    }
    
    
    public async Task<JsonResult> Handle(GetAllTeacher request, CancellationToken cancellationToken)
    {

        var Result=TeacherRepository.GetAllTecher(request.OrderBy, request.PageNumber, request.PageSize);
        return Success(Result,"this is all teacher");
        
    }
}