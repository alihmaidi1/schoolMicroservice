
using infrutructure;
using Infrutructure;
using Repository.Base;
using Teacher.Repository.Teacher;

namespace Repository.Teacher;

public class TeacherRepository:GenericRepository<Domain.Entities.Teacher.Teacher>,ITeacherRepository
{
    public TeacherRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
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


        return true;

    }

    
}