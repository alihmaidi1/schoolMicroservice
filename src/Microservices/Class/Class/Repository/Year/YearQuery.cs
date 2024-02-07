using System.Linq.Expressions;
using ClassDomain.Dto.Year;

namespace Class.Repository.Year;

public static class YearQuery
{
    public static Expression<Func<ClassDomain.Entities.Year.Year, GetAllYearResponse>> ToGetAllYear = Stage =>
        new GetAllYearResponse()
        {
            Id = Stage.Id.Value,
            Name = Stage.Name,
        };


    
}