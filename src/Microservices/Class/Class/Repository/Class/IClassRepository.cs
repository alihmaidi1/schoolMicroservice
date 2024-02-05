using Class.Repository.Base;
using ClassDomain.Entities.Class;

namespace Class.Repository.Class;

public interface IClassRepository:IgenericRepository<ClassDomain.Entities.Class.Class>
{



    public bool IsExists(ClassID ID);
}