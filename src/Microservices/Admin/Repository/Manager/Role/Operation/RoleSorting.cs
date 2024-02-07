using System.Linq.Expressions;

namespace Repository.Manager.Role.Operation;

public static class RoleSorting
{
    
    
    public static List<string> OrderBy = new List<string>()
    {
        "Name",
        "DateCreated"
    };

    
    public static Func<string, Expression<Func<Domain.Entities.Manager.Role.Role, object>>> switchOrdering= key
            
        =>key switch
        {

            "Name" => x => x.Name,
            _ => x => x.DateCreated,

        };
    
    
    
}