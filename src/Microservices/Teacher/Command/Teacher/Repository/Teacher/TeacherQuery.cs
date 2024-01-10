using System.Linq.Expressions;
using Domain.Dto.Teacher;

namespace Teacher.Repository.Teacher;

public static class TeacherQuery
{
    
    public static Expression<Func<Domain.Entities.Teacher.Teacher, GetAllTeacher>> ToGetAllTeacher = Teacher =>
        new GetAllTeacher()
        {
            Id = Teacher.Id.Value,
            Name = Teacher.Name,
            Email = Teacher.Email,
            
            Status = Teacher.status
        };

    
}