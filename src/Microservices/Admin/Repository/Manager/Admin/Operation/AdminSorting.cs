using System.Linq.Expressions;

namespace Repository.Manager.Admin.Operation;

public static class AdminSorting
{
    
    
    public static List<string> OrderBy = new List<string>()
    {
        "Name",
        "Email",
        "DateCreated"
    };

    
    public static Func<string, Expression<Func<Domain.Entities.Manager.Admin.Admin, object>>> switchOrdering= key
            
        =>key switch
        {

            "Name" => x => x.Name,
            "Email"=>x=>x.Email,
            _ => x => x.DateCreated,

        };

}