using System.Linq.Expressions;
using ClassDomain.Dto.Parent;
using ClassDomain.Dto.Year;

namespace Class.Repository.Parent;

public class ParentQuery
{
    
    public static Expression<Func<ClassDomain.Entities.Parent.Parent, GetAllParentResponse>> ToGetAllParent = Parent =>
        new GetAllParentResponse()
        {
            Id = Parent.Id.Value,
            Name = Parent.Name,
            Email = Parent.Email,
            
        };

}