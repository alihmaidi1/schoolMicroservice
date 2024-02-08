using Class.Repository.Base;
using ClassDomain.Dto.ClassYear;
using ClassDomain.Entities.Bill;
using ClassDomain.Entities.Class;
using ClassDomain.Entities.StageClass;
using Common.Entity.EntityOperation;

namespace Class.Repository.ClassYear;

public interface IClassYearRepository:IgenericRepository<ClassDomain.Entities.ClassYear.ClassYear>
{


    public bool IsExists(ClassYearID Id);

    public bool Delete(ClassYearID Id);
    public bool Update(ClassYearID Id ,List<ClassDomain.Entities.Bill.Bill> bills);
    public PageList<GetAllClassYearResponse> GetAllClassYear(ClassID id, int? pageNumber, int? pageSize);


    public GetClassYearResponse GetClassYear(ClassYearID classYearId);

}