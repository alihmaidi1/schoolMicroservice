using Class.Repository.Base;
using ClassDomain.Entities.Semester;
using ClassDomain.Entities.StageClass;

namespace Class.Repository.Semester;

public interface ISemesterRepository:IgenericRepository<ClassDomain.Entities.Semester.Semester>
{


    public bool IsExists(SemesterID ID);


    public bool IsExists(string Name,ClassYearID Id);

    public bool Delete(SemesterID Id);
}