using Common.Entity.EntityOperation;
using Domain.Entities.Teacher;
using Domain.Entities.Vacation;
using Domain.Repository.Base;

namespace Domain.Repository.Vacation;

public interface IVacationRepository:IgenericRepository<Entities.Vacation.Vacation>
{


    public bool IsExists(VacationID Id);


    public bool ChangeVacationStatus(VacationID Id ,bool Status);

    public bool IsExistsAndNotProccessed(VacationID Id,TeacherID teacherId);


    public PageList<Dto.Teacher.Vacation> Vacations(TeacherID teacherId, int? pageNumber, int? pageSize);
}