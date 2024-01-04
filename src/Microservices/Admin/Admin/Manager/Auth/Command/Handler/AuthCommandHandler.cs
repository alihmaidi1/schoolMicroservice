using Common.Jwt;
using Common.OperationResult;
using Domain.Entities.Manager.Admin;
using Domain.Enum;
using Dto.Manager.Auth;
using Infrutructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Manager.Auth.Command;
using Repository.Manager.Admin;
using Repository.Manager.Jwt.Factory;
using Service.Manager.Auth;
using Adminentity=Domain.Entities.Manager.Admin.Admin;
namespace Admin.Manager.Auth.Command.Handler;

public class AuthCommandHandler:OperationResult,
                                IRequestHandler<LoginAdminCommand, JsonResult>,
                                IRequestHandler<LogoutAdminCommand, JsonResult>,
                                IRequestHandler<RefreshAdminTokenCommand, JsonResult>


{

    
    private readonly IHttpContextAccessor _httpContextAccessor;

    private IJwtRepository jwtRepository;
    private readonly ApplicationDbContext DbContext;

    private IAdminRepository AdminRepository;

    private IAuthService AuthService;
    public AuthCommandHandler(IAuthService AuthService,IHttpContextAccessor _httpContextAccessor,ISchemaFactory schemaFactory,IAdminRepository AdminRepository,ApplicationDbContext DbContext)
    {
        this.AuthService = AuthService;
        this._httpContextAccessor = _httpContextAccessor;
        this.jwtRepository = schemaFactory.CreateJwt(JwtSchema.JwtAdmin);
        this.DbContext = DbContext;
        this.AdminRepository = AdminRepository;


    }
    
    public async Task<JsonResult> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
    {

        Adminentity admin = DbContext.Admins
            .Include(x=>x.Role)
            .Select(x=>new Adminentity()
            {
                Id = x.Id,
                Email = x.Email,
                Role = x.Role,
                Password = x.Password
                
            })
            .First(x => x.Email.Equals(request.Email));
        
        if (admin.Password.Equals(request.Password))
        {
            Dictionary<string, string> Permissions = admin.Role.Permissions.ToDictionary(x => x, x => x);
            Permissions.Add("role",admin.Role.Name);
                
            
            var tokens =  jwtRepository.GetTokensInfo(admin.Id,admin.Email,Permissions);
            string adminRefreshToken = tokens.refreshToken;
             DbContext.AdminRefreshTokens.Add(new AdminRefreshToken()
             {
                 
                 Token = adminRefreshToken,
                 ExpireAt = DateTime.UtcNow.AddDays(30),
                 AdminId = admin.Id
                 
             });
             DbContext.SaveChanges();
        
             TokenDto TokenInfo = TokenDto.ToTokenDto(tokens.token, tokens.ExpiredAt, tokens.refreshToken);
        
            return Success(TokenInfo,"You are login successfully");
        }
        
        return Fail("password is not correct");

    }

    public async Task<JsonResult> Handle(LogoutAdminCommand request, CancellationToken cancellationToken)
    {
        
        string Token = _httpContextAccessor.HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];
        bool status = AdminRepository.Logout(Token);
        return Success(status, "You Are Logout Successfully");

    }

    public async Task<JsonResult> Handle(RefreshAdminTokenCommand request, CancellationToken cancellationToken)
    {
        AdminRefreshToken? RefreshToken =  DbContext.AdminRefreshTokens
            .Include(x => x.Admin)
            .ThenInclude(x=>x.Role)
            .Select(x=>new AdminRefreshToken()
            {
                Id = x.Id,
                ExpireAt = x.ExpireAt,
                Admin = new Adminentity()
                {
                    Id = x.Admin.Id,
                    Role = x.Admin.Role,
                    Email = x.Admin.Email,
                    
                },
                Token = x.Token,
                
                
            })
            .FirstOrDefault(x => x.Token.Equals(request.RefreshToken));
        DbContext.AdminRefreshTokens.Remove(RefreshToken);
        Dictionary<string,string> permissions = RefreshToken.Admin.Role.Permissions.ToDictionary(x=>x,x=>x);
        
        permissions.Add("role",RefreshToken.Admin.Role.Name);
        var TokensData =  this.jwtRepository.GetTokensInfo(RefreshToken.Admin.Id,RefreshToken.Admin.Email,permissions);
        TokenDto TokenInfo = TokenDto.ToTokenDto(TokensData.token,TokensData.ExpiredAt,TokensData.refreshToken);
        return Success(TokenInfo);


    }
}