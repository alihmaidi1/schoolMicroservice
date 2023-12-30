using System.Security.Claims;
using Common.OperationResult;
using Domain.Enum;
using Dto.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Password;
using Repository.Manager.Admin;
using Repository.Manager.Jwt;
using Repository.Manager.Jwt.Factory;

namespace Admin.Password.Commands.Handler;

public class PasswordHandler:OperationResult,
    IRequestHandler<ForgetPasswordCommand, JsonResult>,
    IRequestHandler<CheckCodeCommand, JsonResult>,
    IRequestHandler<ChangePasswordCommand, JsonResult>


{
    private IAdminRepository adminRepository;
    
    private readonly IHttpContextAccessor _httpContextAccessor;

    private IJwtRepository jwtRepository;
    public PasswordHandler(IHttpContextAccessor _httpContextAccessor,IAdminRepository adminRepository,ISchemaFactory schemaFactory)
    {

        this._httpContextAccessor = _httpContextAccessor;
        this.jwtRepository = schemaFactory.CreateJwt(JwtSchema.JwtResetAdmin);
        this.adminRepository = adminRepository;


    }
    
    
    public async Task<JsonResult> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
    {

        Domain.Entities.Manager.Admin.Admin admin = adminRepository.GetByEmail(request.Email);
        adminRepository.SendResetCode(admin.Email);
        var tokens = await jwtRepository.GetTokensInfo(admin.Id,admin.Email);
        string Token = jwtRepository.GetToken(admin.Id,admin.Email);
        return Success(Token, "The Email Was Sended Successfully");
    }

    public async Task<JsonResult> Handle(CheckCodeCommand request, CancellationToken cancellationToken)
    {
        var Id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value;
        Domain.Entities.Manager.Admin.Admin admin = adminRepository.GetById(Id);
        var tokens =  await jwtRepository.GetTokensInfo(new Guid(Id),admin.Email);
        TokenDto TokenInfo = TokenDto.ToTokenDto(tokens.token, tokens.ExpiredAt, tokens.refreshToken.Token);

        return Success(TokenInfo, "The Code is Correct");
    }

    public async Task<JsonResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var Id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value;

        adminRepository.ChangePassword(Id, request.Password);
        return Success("password was updated successfully");

    }
}