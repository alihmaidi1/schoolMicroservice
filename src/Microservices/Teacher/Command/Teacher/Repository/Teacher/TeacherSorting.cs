using System.Linq.Expressions;

namespace Teacher.Repository.Teacher;

public static class TeacherSorting
{
    
    public static List<string> OrderBy = new List<string>()
    {
        "Name",
        "Email",
        "Status",
        "DateCreated"
    };

    
    public static Func<string, Expression<Func<Domain.Entities.Teacher.Teacher, object>>> switchOrdering= key
            
        =>key switch
        {

            "Name" => x => x.Name,
            "Email"=>x=>x.Email,
            "Status"=>x=>x.status,
            _ => x => x.DateCreated,

        };

}