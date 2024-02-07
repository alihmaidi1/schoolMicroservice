using System.Linq.Expressions;
using ClassDomain.Dto.ClassYear;

namespace Class.Repository.ClassYear;

public static class ClassYearQuery
{
    
    public static Expression<Func<ClassDomain.Entities.ClassYear.ClassYear, GetAllClassYearResponse>> ToGetAllClassYear = ClassYear =>
        new GetAllClassYearResponse()
        {
            Id = ClassYear.Id.Value,
            Billings = ClassYear.Bills.Select(x=>new BillResponse()
            {
                Id = x.Id,
                Money = x.Money,
                date = x.Date
                
            }).ToList()
        };


}