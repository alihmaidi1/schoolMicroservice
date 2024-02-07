using Domain.Entities.YearVacation;
using Domain.Repository.Base;

namespace Domain.Repository.Year;

public interface IYearRepository:IgenericRepository<Entities.YearVacation.Year>
{


    public bool IsExists(YearVacationID Id);


}