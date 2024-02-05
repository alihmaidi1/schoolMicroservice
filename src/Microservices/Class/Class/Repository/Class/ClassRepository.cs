using Class.Repository.Base;
using ClassDomain.Entities.Class;
using ClassInfrutructure;

namespace Class.Repository.Class;

public class ClassRepository:GenericRepository<ClassDomain.Entities.Class.Class>,IClassRepository
{
    
    
    public ClassRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public bool IsExists(ClassID ID)
    {


        return DbContext.Classes.Any(x=>x.Id==ID);

    }

    
}