using Class.Repository.Base;
using ClassDomain.Dto.Bill;
using ClassDomain.Dto.ClassYear;
using ClassDomain.Dto.Semester;
using ClassDomain.Dto.Student;
using ClassDomain.Entities.Bill;
using ClassDomain.Entities.Class;
using ClassDomain.Entities.StageClass;
using ClassInfrutructure;
using Common.Entity.EntityOperation;
using Microsoft.EntityFrameworkCore;

namespace Class.Repository.ClassYear;

public class ClassYearRepository:GenericRepository<ClassDomain.Entities.ClassYear.ClassYear>,IClassYearRepository
{
    public ClassYearRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public bool IsExists(ClassYearID Id)
    {



        return DbContext.ClassYears.Any(x=>x.Id==Id);
    }


    public PageList<GetAllClassYearResponse> GetAllClassYear(ClassID id,int? pageNumber, int? pageSize)
    {
        
        var Result = DbContext.ClassYears
            .Where(x=>x.ClassId==id)
            .Select(ClassYearQuery.ToGetAllClassYear)
            .ToPagedList(pageNumber,pageSize);

        return Result;

    }

    public bool Update(ClassYearID Id, List<ClassDomain.Entities.Bill.Bill> bills)
    {

        DbContext.Bills.Where(x => x.ClassYearId==Id ).ExecuteDelete();
        DbContext.Bills.AddRange(bills);
        DbContext.SaveChanges();
        return true;

    }

    public bool Delete(ClassYearID Id)
    {

        DbContext.ClassYears.Where(x => x.Id == Id)
            .ExecuteUpdate(setter => setter.SetProperty(x => x.DateDeleted, DateTime.Now));
        DbContext.SaveChanges();
        return true;
    }

    public GetClassYearResponse GetClassYear(ClassYearID classYearId)
    {

        var Result=DbContext
            .ClassYears
            .Include(x=>x.Bills)
            .Include(x=>x.Semesters)
            .Include(x=>x.Class)
            .Include(x=>x.Year)
            .Include(x=>x.Students)
            .Select(x=>new GetClassYearResponse()
            {
                
                Id = x.Id,
                ClassName = x.Class.Name,
                YearName = x.Year.Name,
                Students = x.Students.Select(y=>new GetStudentClassResponse()
                {
                    
                    Id = y.Id,
                    Name = y.Name
                    
                }).ToList(),
                Semesters = x.Semesters.Select(y=>new GetSemesterResponse()
                {
                    
                    Id = y.Id,
                    Name = y.Name,
                }).ToList(),
                Bills = x.Bills.Select(y=>new GetBillResponse()
                {
                    
                    Id = y.Id,
                    Money = y.Money,
                    Date = y.Date,
                    
                }).ToList()
                
            })
            .First(x=>x.Id==classYearId);
        return Result;

    }


}