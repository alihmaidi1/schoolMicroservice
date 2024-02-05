using Class.Repository.Base;
using ClassDomain.Entities.Subject;

namespace Class.Repository.Subject;

public interface ISubjectRepository:IgenericRepository<ClassDomain.Entities.Subject.Subject>
{

    public bool IsExists(SubjectID Id);

    public bool IsExists(string Name);

    public bool IsExists(SubjectID Id, string Name);

}
