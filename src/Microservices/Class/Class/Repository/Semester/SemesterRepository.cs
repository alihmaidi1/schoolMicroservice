using Class.Repository.Base;
using ClassDomain.Entities.Semester;
using ClassDomain.Entities.StageClass;
using ClassInfrutructure;
using Microsoft.EntityFrameworkCore;

namespace Class.Repository.Semester;

public class SemesterRepository:GenericRepository<ClassDomain.Entities.Semester.Semester>,ISemesterRepository
{
    public SemesterRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public bool IsExists(SemesterID ID)
    {


        return DbContext.Semesters.Any(x => x.Id == ID);

    }


    public bool IsExists(string Name, ClassYearID Id)
    {


        return DbContext.Semesters.Any(x => x.ClassYearId == Id && x.Name.Equals(Name));

    }

    public bool Delete(SemesterID Id)
    {

        DbContext.Semesters.Where(x => x.Id == Id).ExecuteUpdate(setter=>setter.SetProperty(x=>x.DateDeleted,DateTime.Now));
        DbContext.SaveChanges();
        return true;

    }

    
}