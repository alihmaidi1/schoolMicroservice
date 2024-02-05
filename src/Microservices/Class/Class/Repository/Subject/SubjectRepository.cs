using Class.Repository.Base;
using ClassDomain.Entities.Subject;
using ClassInfrutructure;

namespace Class.Repository.Subject;

public class SubjectRepository:GenericRepository<ClassDomain.Entities.Subject.Subject>,ISubjectRepository
{
    public SubjectRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public bool IsExists(SubjectID Id)
    {
        
        return DbContext.Subjects.Any(x => x.Id == Id);
    }

    public bool IsExists(string Name)
    {
        return DbContext.Subjects.Any(x=>x.Name.Equals(Name));
    }


    public bool IsExists(SubjectID Id, string Name)
    {
        
        return DbContext.Subjects.Any(x=>x.Name.Equals(Name)&& x.Id!=Id);
        
    }

}