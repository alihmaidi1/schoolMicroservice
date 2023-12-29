using Domain.Entities.Manager.Admin;

namespace Repository.Manager.Jwt;

public interface IJwtRepository
{
    
    public Task<(AdminRefreshToken refreshToken,string token,int ExpiredAt)> GetTokensInfo(Guid Id,string Email);

    public string GetToken(Guid Id,string Email);


}