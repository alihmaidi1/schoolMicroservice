using Common.Entity.EntityOperation;
using Domain.Dto.Teacher;
using Domain.Entities.Teacher;
using Domain.Model.Teacher.Query;
using Domain.Repository.Base;

namespace Teacher.Repository.Teacher;

public interface ITeacherRepository:IgenericRepository<Domain.Entities.Teacher.Teacher>
{


    public bool IsExists(string Email);

    public bool IsUnique(TeacherID Id,string Email);

    
    public bool ChangeStatus(TeacherID Id,bool status);

    public bool IsExists(TeacherID Id);
    public bool AddTeacher(string Name,string Email,string Password);

    public bool UpdateTeacher(TeacherID Id,string Name,string Email,string Password);

    public GetTeacherResponse GetTeacher(TeacherID Id );
    
    public bool Delete(TeacherID Id);
    
    public PageList<Domain.Dto.Teacher.GetAllTeacher> GetAllTecher(string? OrderBy, int? pageNumber, int? pageSize);

}