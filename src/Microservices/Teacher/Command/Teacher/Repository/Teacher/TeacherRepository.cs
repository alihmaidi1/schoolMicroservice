
using Common.Entity.EntityOperation;
using Common.Repository;
using Domain.Dto.Teacher;
using Domain.Entities.Teacher;
using infrutructure;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Teacher.Repository.Teacher;
using ApplicationDbContext = Teacherinfrutructure.ApplicationDbContext;

namespace Repository.Teacher;

public class TeacherRepository:GenericRepository<Domain.Entities.Teacher.Teacher>,ITeacherRepository
{
    public TeacherRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public bool ChangeStatus(TeacherID Id, bool status)
    {

        DbContext.Teachers.Update(new Domain.Entities.Teacher.Teacher()
        {
            Id = Id,
            status = status
        });
        DbContext.SaveChanges();
        return true;

    }


    public bool IsExists(string Email)
    {
        return DbContext.Teachers.Any(x=>x.Email.Equals(Email));
    }

    public bool AddTeacher(string Name, string Email, string Password)
    {

        Domain.Entities.Teacher.Teacher Teacher = new Domain.Entities.Teacher.Teacher()
        {

            Name = Name,
            Email = Email,
            Password = Password,
            status = true


        };

        DbContext.Teachers.Add(Teacher);
        DbContext.SaveChanges();

        return true;

    }

    public bool IsExists(TeacherID Id)
    {


        return DbContext.Teachers.Any(x => x.Id == Id);


    }

    public bool IsUnique(TeacherID Id, string Email)
    {


        return DbContext.Teachers.Any(x => x.Email.Equals(Email) && x.Id != Id);
    }

    public bool UpdateTeacher(TeacherID Id, string Name, string Email, string Password)
    {
        
        Domain.Entities.Teacher.Teacher teacher = new Domain.Entities.Teacher.Teacher()
        {
            Name = Name,
            Email = Email,
            Password = Password,
            Id = Id
        };
        DbContext.Teachers.Update(teacher);
        DbContext.SaveChanges();
        return true;

    }


    public PageList<Domain.Dto.Teacher.GetAllTeacher> GetAllTecher(string? OrderBy, int? pageNumber, int? pageSize)
    {

        
        
        var Result = DbContext.Teachers
            .Sort<TeacherID,Domain.Entities.Teacher.Teacher>(OrderBy, TeacherSorting.switchOrdering)
            .Select(TeacherQuery.ToGetAllTeacher)
            .ToPagedList(pageNumber,pageSize);


        return Result;
    }

    public bool Delete(TeacherID Id)
    {


        DbContext.Teachers.Where(x => x.Id == Id)
            .ExecuteUpdate(setter => setter.SetProperty(x => x.DateDeleted, DateTime.Now));

        DbContext.SaveChanges();
        return true;

    }


    public GetTeacherResponse GetTeacher(TeacherID Id)
    {

        GetTeacherResponse teacher = DbContext
            .Teachers
            .Include(x=>x.Warnings)
            .ThenInclude(x=>x.Manager)
            .Include(x=>x.Vacations)
            .ThenInclude(x=>x.Year)
            .Include(x=>x.Vacations)
            .ThenInclude(x=>x.Manager)
            .Select(x=>new GetTeacherResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Status = x.status,
                Warnings = x.Warnings.Select(y=>new Warning()
                {
                    Id = y.Id,
                    ManagerName = y.Manager.Name,
                    Reason = y.Reason
                    
                }).ToList(),
                
                Vacations = x.Vacations.Select(z=>new Vacation()
                {
                    
                    Id = z.Id,
                    ManagerName = z.Manager.Name,
                    Reason = z.Reason,
                    Year = z.Year.Name
                    
                }).ToList()
                
            })
            .First(x=>x.Id==Id);

        return teacher;



    }

}