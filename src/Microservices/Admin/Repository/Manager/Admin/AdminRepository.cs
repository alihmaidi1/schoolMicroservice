using System.Security.Claims;
using Common.Email;
using Common.Entity.EntityOperation;
using Common.Enum;
using Common.ExtensionMethod;
using Common.Redis;
using Common.Repository;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Manager.Role;
using Domain.Enum;
using Dto.Manager.Admin;
using Dto.Manager.Role;
using Hangfire;
using Infrutructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Manager.Admin.Operation;
using Repository.Manager.Role.Operation;

namespace Repository.Manager.Admin;

public class AdminRepository:GenericRepository<Domain.Entities.Manager.Admin.Admin>,IAdminRepository
{
    public readonly ICacheRepository CacheRepository;
    private IMailService MailService;
    private readonly IHttpContextAccessor httpContextAccessor;

    public AdminRepository(IHttpContextAccessor httpContextAccessor,IMailService MailService,ICacheRepository CacheRepository,ApplicationDbContext DbContext) : base(DbContext)
    {
        this.httpContextAccessor = httpContextAccessor;
        this.MailService = MailService;
        this.CacheRepository = CacheRepository;
    }

    public bool IsEmailExists(string Email)
    {
        
        return this.DbContext.Admins.Any(x => x.Email.Equals(Email));
        
    }

    
    public bool IsEmailExists(string Email,AdminID adminId)
    {
        
        return this.DbContext.Admins.Any(x => x.Email.Equals(Email)&&x.Id!=adminId);
        
    }
    public Domain.Entities.Manager.Admin.Admin GetByEmail(string Email)
    {


        return DbContext.Admins.First();

    }


    public bool Logout(string Token)
    {
        
        CacheRepository.RemoveData($"Token:{Token}");
        return true;
        
    }

    public async Task<bool> SendResetCode(string email)
    {
        
        string Code= string.Empty.GenerateCode();

        DbContext.Admins
            .Where(x => x.Email.Equals(email))
            .ExecuteUpdate(setter => setter.SetProperty(b => b.ResetCode, Code));

        DbContext.SaveChanges();
        BackgroundJob.Enqueue(()=>MailService.SendMail(email,"Reset Password School",$"you Can Reset Your Password By This Code : {Code}"));
        return true;

    }


    public bool CheckCode(string code)
    {
        
        var Id = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value;
        var Token = httpContextAccessor.HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];
        var admin =DbContext.Admins.Single(x=>x.Id==new Guid(Id));
        
        if (!admin.ResetCode.Equals(code))
        {
            return false;
        }
        CacheRepository.RemoveData("Token:" + Token);
        return true;
        
        
    }


    public Domain.Entities.Manager.Admin.Admin GetById(string Id)
    {

        return DbContext.Admins.Single(x => x.Id == new Guid(Id));


    }


    public bool ChangePassword(string Id, string password)
    {

        DbContext.Admins
            .Where(x => x.Id == new Guid(Id))
            .ExecuteUpdate(setter => setter.SetProperty(x => x.Password, password));
        DbContext.SaveChanges();


        return true;

    }


    public bool Add(string Email, string Password, RoleID roleId, string Name)
    {

        var Admin = new Domain.Entities.Manager.Admin.Admin()
        {

            Email = Email,
            Password = Password,
            Name = Name,
            RoleId = roleId
        };
        DbContext.Admins.Add(Admin);
        DbContext.SaveChanges();
        return true;

    }

    public bool IsExists(AdminID Id)
    {

        return DbContext.Admins.Any(x => x.Id == Id&& x.Name.Equals(RoleEnum.SuperAdmin.ToString()));

    }

    public bool Update(AdminID Id, string Email, string Password, RoleID roleId, string Name)
    {
        
        
        var Admin = new Domain.Entities.Manager.Admin.Admin()
        {

            Email = Email,
            Password = Password,
            Name = Name,
            RoleId = roleId,
            Id = Id
        };
        DbContext.Admins.Update(Admin);
        DbContext.SaveChanges();
        return true;

    }

    public PageList<GetAllAdmin> GetAlladmin(string? OrderBy, int? pageNumber, int? pageSize)
    {
        
        var Result = DbContext.Admins
            .Where(x=>!x.Name.Equals(RoleEnum.SuperAdmin.ToString()))
            .Sort<AdminID,Domain.Entities.Manager.Admin.Admin>(OrderBy, AdminSorting.switchOrdering)
            .Select(AdminQuery.ToGetAllAdmin)
            .ToPagedList(pageNumber,pageSize);
        return Result;

        
        
    }

    
}