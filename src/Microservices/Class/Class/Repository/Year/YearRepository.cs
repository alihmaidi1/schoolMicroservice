using Class.Repository.Base;
using Class.Repository.Stage;
using ClassDomain.Dto.Year;
using ClassDomain.Entities.Stage;
using ClassDomain.Entities.Year;
using ClassInfrutructure;
using Common.Entity.EntityOperation;
using Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace Class.Repository.Year;

public class YearRepository:GenericRepository<ClassDomain.Entities.Year.Year>,IYearRepository
{
    public YearRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public bool IsExists(string Name)
    {

        return DbContext.Years.Any(x => x.Name.Equals(Name));
        
    }

    public bool IsExists(string Name, YearID id)
    {


        return DbContext.Years.Any(x => x.Name.Equals(Name) && x.Id != id);
    }

    public bool Delete(YearID Id)
    {
        DbContext.Years.Where(x=>x.Id==Id).ExecuteUpdate(setter => setter.SetProperty(x => x.DateDeleted, DateTime.Now));
        DbContext.SaveChanges();
        return true;
    }


    public bool IsExists(YearID id)
    {

        return DbContext.Years.Any(x => x.Id == id);
    }

    public PageList<GetAllYearResponse> GetAllYear(string? OrderBy, int? pageNumber, int? pageSize)
    {
     
        
        var Result = DbContext.Years
            .Sort<YearID,ClassDomain.Entities.Year.Year>(OrderBy, YearSorting.switchOrdering)
            .Select(YearQuery.ToGetAllYear)
            .ToPagedList(pageNumber,pageSize);


        return Result;
        
    }


}