using Domain.Entities.YearVacation;
using Repository.Base;
using Teacherinfrutructure;

namespace Domain.Repository.Year;

public class YearRepository:GenericRepository<Entities.YearVacation.Year>,IYearRepository
{
    public YearRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }


    public bool IsExists(YearVacationID Id)
    {


        return DbContext.Year.Any(x=>x.Id==Id);


    }

}