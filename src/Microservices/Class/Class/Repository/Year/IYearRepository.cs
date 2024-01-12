using Class.Repository.Base;
using ClassDomain.AppMetaData;
using ClassDomain.Dto.Stage;
using ClassDomain.Dto.Year;
using ClassDomain.Entities.Year;
using Common.Entity.EntityOperation;

namespace Class.Repository.Year;

public interface IYearRepository:IgenericRepository<ClassDomain.Entities.Year.Year>
{

    public bool IsExists(string Name);

    public bool IsExists(string Name,YearID id );

    public bool IsExists(YearID id);
    
    
    public PageList<GetAllYearResponse> GetAllYear(string? OrderBy, int? pageNumber, int? pageSize);


    
}