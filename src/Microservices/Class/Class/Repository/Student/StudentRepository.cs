using Class.Repository.Base;
using ClassDomain.Dto.Student;
using ClassDomain.Entities.Student;
using ClassInfrutructure;
using Common.Entity.EntityOperation;
using Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace Class.Repository.Student;

public class StudentRepository:GenericRepository<ClassDomain.Entities.Student.Student>,IStudentRepository
{
    public StudentRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }


    public bool IsExists(string Email)
    {

        return DbContext.Students.Any(x=>x.Email.Equals(Email));
    }


    public bool IsExists(StudentID Id, string Email)
    {


        return DbContext.Students.Any(x=>x.Id!=Id&&x.Email.Equals(Email));
    }


    public PageList<GetAllStudentResponse> GetAll(string? OrderBy, int? pageNumber, int? pageSize, string? Name, string? ParentName)
    {
        
        // List<GetAllStudentResponse> students=DbContext.Students.

        var Result = DbContext.Students
        .Sort<StudentID,ClassDomain.Entities.Student.Student>(OrderBy, StudentSorting.switchOrdering)
        .Include(x=>x.Parent)
        .Where(x=>x.Name.Contains(Name??""))
        .Where(x=>x.Parent.Name.Contains(ParentName??""))
        .Select(x=>new GetAllStudentResponse()
        {
            
            Id = x.Id,
            Name = x.Name,
            ParentName = x.Parent.Name
            
        })
        .ToPagedList(pageNumber,pageSize);
        
        return Result;

    }

    
}