using System.Linq.Expressions;

namespace Class.Repository.Student;

public static class StudentSorting
{
    
    public static List<string> OrderBy = new List<string>()
    {
        "Name",
    };

    
    public static Func<string, Expression<Func<ClassDomain.Entities.Student.Student, object>>> switchOrdering= key
            
        =>key switch
        {
            "Name" => x => x.Name,
            _ => x => x.DateCreated,
        };

    
}