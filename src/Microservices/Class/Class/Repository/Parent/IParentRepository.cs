using Class.Repository.Base;
using ClassDomain.Dto.Parent;
using ClassDomain.Entities.Parent;
using Common.Entity.EntityOperation;

namespace Class.Repository.Parent;

public interface IParentRepository:IgenericRepository<ClassDomain.Entities.Parent.Parent>
{

    public PageList<GetAllParentResponse> GetAllParent(string? OrderBy, int? pageNumber, int? pageSize);


    public bool IsExists(ParentID Id);


    public bool IsExists(string Email);

    public bool IsExists(string Email,ParentID Id );


    public bool Update(ParentID id,string Name,string Email);


    public bool UpdatePassword(ParentID Id, string Password);


    public bool Delete(ParentID Id);
    
    public GetParentResponse GetParent(ParentID Id);

}