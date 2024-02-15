using Class.Repository.Student;
using ClassDomain.Model.Student.Query;
using Common.CQRS;
using Common.OperationResult;
using Microsoft.AspNetCore.Mvc;

namespace Class.Student.Query.Handler;

public class StudentQueryHandler:OperationResult,
    IQueryHandler<GetAllStudentQuery>
{
    private IStudentRepository StudentRepository;
    public StudentQueryHandler(IStudentRepository StudentRepository)
    {

        this.StudentRepository = StudentRepository;

    }
    
    public async Task<JsonResult> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
    {
        var Result = StudentRepository.GetAll(request.OrderBy,request.PageNumber,request.PageSize,request.Name,request.ParentName);
        return Success(Result);
    }
}