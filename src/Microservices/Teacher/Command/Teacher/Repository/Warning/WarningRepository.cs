using Common.Entity.EntityOperation;
using Domain.Entities.Teacher;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Teacherinfrutructure;

namespace Domain.Repository.Warning;

public class WarningRepository:GenericRepository<Entities.Warning.Warning>,IWarningRepository
{
    public WarningRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }


    public bool IsExists(Guid Id)
    {

        return DbContext.Warnings.Any(x => x.Id == Id);
    }


    public PageList<Dto.Teacher.Warning> GetWarnings(TeacherID teacherId,int? pageNumber, int? pageSize)
    {

        return DbContext
            .Warnings
            .Where(x=>x.TeacherId==teacherId)
            .Include(x=>x.Manager)
            .Select(x=>new Dto.Teacher.Warning()
            {
                 
                Id = x.Id,
                ManagerName = x.Manager.Name,
                Reason = x.Reason
                
            })
            .ToPagedList(pageNumber,pageSize);

    }

    
}