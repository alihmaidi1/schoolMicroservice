using Common.OperationResult;
using Domain.Entities.Manager.Admin;
using Dto.Auth;
using Infrutructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Auth.Command;
using Repository.Manager.Admin;
using Repository.Manager.Jwt;

namespace Admin.Auth.Command.Handler;

public class AuthCommandHandler:OperationResult,
                                IRequestHandler<LoginAdminCommand, JsonResult>,
                                IRequestHandler<LogoutAdminCommand, JsonResult>,
                                IRequestHandler<RefreshAdminTokenCommand, JsonResult>


{

    
    private readonly IHttpContextAccessor _httpContextAccessor;

    private IJwtRepository jwtRepository;
    private readonly ApplicationDbContext DbContext;

    private IAdminRepository AdminRepository;

    public AuthCommandHandler(IHttpContextAccessor _httpContextAccessor,IJwtRepository jwtRepository,IAdminRepository AdminRepository,ApplicationDbContext DbContext)
    {
        this._httpContextAccessor = _httpContextAccessor;
        this.jwtRepository = jwtRepository;
        this.DbContext = DbContext;
        this.AdminRepository = AdminRepository;


    }
    
    public async Task<JsonResult> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Manager.Admin.Admin admin = this.AdminRepository.GetByEmail(request.Email);
        
        if (admin.Password.Equals(request.Password))
        {
            var tokens = await jwtRepository.GetTokensInfo(admin.Id,admin.Email);
            AdminRefreshToken adminRefreshToken = tokens.refreshToken;
             admin.RefreshTokens.Add(adminRefreshToken);
             DbContext.SaveChanges();

             TokenDto TokenInfo = TokenDto.ToTokenDto(tokens.token, tokens.ExpiredAt, tokens.refreshToken.Token);

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
            .Select(x=>new AdminRefreshToken()
            {
                Id = x.Id,
                ExpireAt = x.ExpireAt,
                Admin = x.Admin,
                Token = x.Token
                
            })
            .FirstOrDefault(x => x.Token.Equals(request.RefreshToken));
        DbContext.AdminRefreshTokens.Remove(RefreshToken);
        var TokensData = await this.jwtRepository.GetTokensInfo(RefreshToken.Admin.Id,RefreshToken.Admin.Email);
        TokenDto TokenInfo = TokenDto.ToTokenDto(TokensData.token,TokensData.ExpiredAt,TokensData.refreshToken.Token);
        return Success(TokenInfo);


    }
}