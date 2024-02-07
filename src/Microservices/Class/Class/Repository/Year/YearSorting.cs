using System.Linq.Expressions;

namespace Class.Repository.Year;

public class YearSorting
{
    
    public static List<string> OrderBy = new List<string>()
    {
        "Name",
    };

    
    public static Func<string, Expression<Func<ClassDomain.Entities.Year.Year, object>>> switchOrdering= key
            
        =>key switch
        {

            "Name" => x => x.Name,
            _ => x => x.DateCreated,

        };

}