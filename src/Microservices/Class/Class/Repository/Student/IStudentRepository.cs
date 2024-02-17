using Class.Repository.Base;
using ClassDomain.Dto.Student;
using ClassDomain.Entities.Student;
using Common.Entity.EntityOperation;
using StackExchange.Redis;

namespace Class.Repository.Student;

public interface IStudentRepository:IgenericRepository<ClassDomain.Entities.Student.Student>
{

    public bool IsExists(string Email);

    public bool IsExists(StudentID Id ,string Email);


    public bool IsExists(int Number);

    public bool IsExists(StudentID Id,int Number);

    public bool IsExists(StudentID Id);


    public bool Delete(StudentID id);
    
    public PageList<GetAllStudentResponse> GetAll(string? OrderBy, int? pageNumber, int? pageSize,string? Name,string? ParentName);

}