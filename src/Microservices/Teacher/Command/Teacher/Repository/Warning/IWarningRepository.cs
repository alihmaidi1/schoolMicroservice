using Common.Entity.EntityOperation;
using Domain.Entities.Teacher;
using Domain.Repository.Base;

namespace Domain.Repository.Warning;

public interface IWarningRepository:IgenericRepository<Entities.Warning.Warning>
{


    public bool IsExists(Guid Id);

    public PageList<Dto.Teacher.Warning> GetWarnings(TeacherID teacherId,int? pageNumber, int? pageSize);
}