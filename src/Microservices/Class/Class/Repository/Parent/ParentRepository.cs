using Class.Repository.Base;
using ClassDomain.Dto.Parent;
using ClassDomain.Dto.Student;
using ClassDomain.Entities.Parent;
using ClassInfrutructure;
using Common.Entity.EntityOperation;
using Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace Class.Repository.Parent;

public class ParentRepository:GenericRepository<ClassDomain.Entities.Parent.Parent>,IParentRepository
{
    public ParentRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }


    public PageList<GetAllParentResponse> GetAllParent(string? OrderBy, int? pageNumber, int? pageSize)
    {

        var Result = DbContext.Parents
            .Sort<ParentID,ClassDomain.Entities.Parent.Parent>(OrderBy, ParentSorting.switchOrdering)
            .Select(ParentQuery.ToGetAllParent)
            .ToPagedList(pageNumber,pageSize);


        return Result;

    }


    public bool IsExists(ParentID Id)
    {
        return DbContext.Parents.Any(x => x.Id == Id);
    }


    public GetParentResponse GetParent(ParentID Id)
    {


        return DbContext
            .Parents
            .Include(x => x.Students)
            .Select(x=>new GetParentResponse()
            {
                
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Students = x.Students.Select(y=>new GetStudentClassResponse()
                {
                    Id = y.Id,
                    Name = y.Name,
                }).ToList()
                
            })
            .First(x=>x.Id==Id);

    }


    public bool IsExists(string Email)
    {

        return DbContext.Parents.Any(x => x.Email.Equals(Email));
    }

    public bool IsExists(string Email, ParentID Id)
    {


        return DbContext.Parents.Any(x=>x.Email.Equals(Email)&&x.Id!=Id);


    }

    public bool Update(ParentID id, string Name, string Email)
    {

        DbContext.Parents.Where(x => x.Id == id).ExecuteUpdate(setter =>
            setter
                .SetProperty(x => x.Name, Name)
                .SetProperty(x => x.Email, Email));

        DbContext.SaveChanges();
        return true;


    }


    public bool UpdatePassword(ParentID Id, string Password)
    {

        DbContext.Parents.Where(x => x.Id == Id).ExecuteUpdate(setter=>setter.SetProperty(x=>x.Password,Password));
        DbContext.SaveChanges();
        return true;
    }

    public bool Delete(ParentID Id)
    {

         DbContext.Parents.Where(x=>x.Id==Id).ExecuteUpdate(setter=>setter.SetProperty(x=>x.DateDeleted,DateTime.Now));
         DbContext.SaveChanges();
         return true;


    }

}