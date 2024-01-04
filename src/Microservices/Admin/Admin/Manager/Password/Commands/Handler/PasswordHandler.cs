using System.Security.Claims;
using Common.Jwt;
using Common.OperationResult;
using Domain.Enum;
using Dto.Manager.Auth;
using Infrutructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Manager.Password.Command;
using Repository.Manager.Admin;
using Repository.Manager.Jwt.Factory;
using AdminEntity=Domain.Entities.Manager.Admin.Admin;
namespace Admin.Manager.Password.Commands.Handler;

public class PasswordHandler:OperationResult,
    IRequestHandler<ForgetPasswordCommand, JsonResult>,
    IRequestHandler<CheckCodeCommand, JsonResult>,
    IRequestHandler<ChangePasswordCommand, JsonResult>


{
    private IAdminRepository adminRepository;
    
    private readonly IHttpContextAccessor _httpContextAccessor;

    private IJwtRepository jwtRepository;

    
    private readonly ApplicationDbContext DbContext;

    public PasswordHandler(ApplicationDbContext DbContext,IHttpContextAccessor _httpContextAccessor,IAdminRepository adminRepository,ISchemaFactory schemaFactory)
    {

        this.DbContext = DbContext;
        this._httpContextAccessor = _httpContextAccessor;
        this.jwtRepository = schemaFactory.CreateJwt(JwtSchema.JwtResetAdmin);
        this.adminRepository = adminRepository;


    }
    
    
    public async Task<JsonResult> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
    {

        AdminEntity admin = DbContext.Admins.First(x=>x.Email.Equals(request.Email));
        adminRepository.SendResetCode(admin.Email);
        string Token = jwtRepository.GetToken(admin.Id,admin.Email);
        return Success(Token, "The Email Was Sended Successfully");
    }

    public async Task<JsonResult> Handle(CheckCodeCommand request, CancellationToken cancellationToken)
    {
        var Id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value;
        AdminEntity admin = DbContext.Admins
            .Include(x=>x.Role)
            .Select(x=>new AdminEntity()
            {
                Id = x.Id,
                Email = x.Email,
                Role = x.Role
                
            }).First(x=>x.Id==new Guid(Id));
        Dictionary<string,string> permission = admin.Role.Permissions.ToDictionary(x=>x,x=>x);
        permission.Add("role",admin.Role.Name);
        var tokens =  jwtRepository.GetTokensInfo(new Guid(Id),admin.Email,permission);
        TokenDto TokenInfo = TokenDto.ToTokenDto(tokens.token, tokens.ExpiredAt, tokens.refreshToken);
        return Success(TokenInfo, "The Code is Correct");
    }

    public async Task<JsonResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
     
        
        var Id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value;
        adminRepository.ChangePassword(Id, request.Password);
        return Success("password was updated successfully");

    }
}