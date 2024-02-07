namespace Common.Jwt;

public interface IJwtRepository
{
    
    public (string refreshToken,string token,int ExpiredAt) GetTokensInfo(Guid Id,string Email,Dictionary<string,string>? Claims=null);

    public string GetToken(Guid Id,string Email,Dictionary<string,string>? Claims=null);

    
    
    
}