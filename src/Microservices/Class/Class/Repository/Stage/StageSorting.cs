using System.Linq.Expressions;

namespace Class.Repository.Stage;

public static class StageSorting
{
    
    public static List<string> OrderBy = new List<string>()
    {
        "Name",
    };

    
    public static Func<string, Expression<Func<ClassDomain.Entities.Stage.Stage, object>>> switchOrdering= key
            
        =>key switch
        {

            "Name" => x => x.Name,
            _ => x => x.DateCreated,

        };

}