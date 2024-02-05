using Common.Entity.EntityOperation;
using Domain.Entities.Teacher;
using Domain.Entities.Vacation;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Teacherinfrutructure;

namespace Domain.Repository.Vacation;

public class VacationRepository:GenericRepository<Entities.Vacation.Vacation>,IVacationRepository
{
    public VacationRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public bool IsExists(VacationID Id)
    {
        
        return DbContext.Vacations.Any(x=>x.Id==Id);


    }

    public bool ChangeVacationStatus(VacationID Id, bool Status)
    {


        DbContext.Vacations.Where(x => x.Id == Id)
            .ExecuteUpdate(setter => setter.SetProperty(x => x.Status, Status));

        DbContext.SaveChanges();
        return true;

    }

    public bool IsExistsAndNotProccessed(VacationID Id, TeacherID teacherId)
    {


        return DbContext.Vacations.Any(x => x.Id == Id &&x.Status==null&&x.TeacherId==teacherId);

    }

    public PageList<Dto.Teacher.Vacation> Vacations(TeacherID teacherId, int? pageNumber, int? pageSize)
    {


        return DbContext
            .Vacations
            .Where(x=>x.TeacherId==teacherId)
            .Include(x=>x.Manager)
            .Include(x=>x.Year)
            .Select(x=>new Dto.Teacher.Vacation()
            {
                 
                Id = x.Id,
                Status =x.Status,
                ManagerName = x.Manager.Name,
                Year = x.Year.Name,
                Reason = x.Reason
                
            })
            .ToPagedList(pageNumber,pageSize);
    }


}