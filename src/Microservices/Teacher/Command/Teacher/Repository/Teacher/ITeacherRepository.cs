using Domain.Repository.Base;

namespace Teacher.Repository.Teacher;

public interface ITeacherRepository:IgenericRepository<Domain.Entities.Teacher.Teacher>
{


    public bool IsExists(string Email);

    public bool AddTeacher(string Name,string Email,string Password);



}