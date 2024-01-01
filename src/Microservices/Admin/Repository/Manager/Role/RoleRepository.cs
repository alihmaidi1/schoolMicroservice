using Common.EntityOperation;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Manager.Role;
using Domain.Enum;
using Dto.Manager.Role;
using Infrutructure;
using Repository.Base;
using Repository.Manager.Admin;
using Repository.Manager.Admin.Operation;
using Repository.Manager.Role.Operation;

namespace Repository.Manager.Role;

public class RoleRepository:GenericRepository<Domain.Entities.Manager.Role.Role>,IRoleRepository
{
    public RoleRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }


    public bool AddRole(string name, List<string> Permissions)
    {
        var Role = new Domain.Entities.Manager.Role.Role()
        {
            Name = name,
            Permissions = Permissions
        };
        DbContext.Roles.Add(Role);
        DbContext.SaveChanges();
        return true;
    }

    public bool IsExists(string Name)
    {
        
        return DbContext.Roles.Any(x=>x.Name.Equals(Name));

    }


    public bool IsExists(string Name, RoleID Id)
    {
        return DbContext.Roles.Any(x => x.Name.Equals(Name) && x.Id != Id);
    }

    public bool IsExists(RoleID Id)
    {

        return DbContext.Roles.Any(x => x.Id == Id&&!x.Name.Equals(RoleEnum.SuperAdmin.ToString()));
        
    }

    public bool UpdateRole(RoleID Id, string name, List<string> Permissions)
    {

        var Role = new Domain.Entities.Manager.Role.Role()
        {

            Id = Id,
            Name = name,
            Permissions = Permissions
            

        };
        
        DbContext.Roles.Update(Role);
        DbContext.SaveChanges();
        return true;

    }


    public bool Delete(RoleID Id)
    {
        DbContext.Roles.Remove(new Domain.Entities.Manager.Role.Role()
        {
            Id = Id
        });
        DbContext.SaveChanges();
        return true;

    }


    public PageList<GetAllRole> GetAll(string? OrderBy, int? pageNumber, int? pageSize)
    {
        
        PageList<GetAllRole> Result = DbContext.Roles
            .Where(x=>!x.Name.Equals(RoleEnum.SuperAdmin.ToString()))
            .Sort<RoleID, Domain.Entities.Manager.Role.Role>(OrderBy, RoleSorting.switchOrdering)
            .Select(RoleQuery.ToGetAllRole)
            .ToPagedList(pageNumber, pageSize);
        
        return Result;
    }


    public PageList<GetAllAdminByRole> GetAdminById(RoleID Id, string? OrderBy, int? pageNumber, int? pageSize)
    {


        var Result = DbContext.Admins
            .Where(x => x.RoleId == Id)
            .Sort<AdminID,Domain.Entities.Manager.Admin.Admin>(OrderBy, AdminSorting.switchOrdering)
            .Select(RoleQuery.ToGetAllAdmin)
            .ToPagedList(pageNumber,pageSize);
        
        return Result;


    }

    
}