using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Common.Jwt;
using Common.Redis;
using Domain.Entities.Manager.Admin;
using Infrutructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Repository.Manager.Jwt;

public class JwtRepository:IJwtRepository
{
    
    public readonly JwtSetting JwtOption;
    public readonly ApplicationDbContext Context; 

    public readonly ICacheRepository CacheRepository;

    public JwtRepository(IOptions<JwtSetting>  Setting, ApplicationDbContext DbContext, ICacheRepository cacheRepository)
    {

        
        this.Context = DbContext;
        this.CacheRepository = cacheRepository;
        this.JwtOption = Setting.Value;

    }
    
    
     public  async Task<(AdminRefreshToken refreshToken,string token,int ExpiredAt)> GetTokensInfo(Guid Id,string Email)  
    {
        
        
        string Token = GetToken(Id,Email);
        AdminRefreshToken RefreshToken = GenerateRefreshToken();
        return (RefreshToken, Token,(int )JwtOption.DurationInMinute * 60);

    }

    
    
    
    
    public string GetToken(Guid Id,string Email)
    {
        var claims = CreateClaim(Id,Email);
        var signingCredentials = GetSigningCredentials(JwtOption);
        var JwtToken = GetJwtToken(JwtOption, claims, signingCredentials);
        var Token = new JwtSecurityTokenHandler().WriteToken(JwtToken);
        var ExpiredAt = DateTimeOffset.Now.AddMinutes(JwtOption.DurationInMinute);
        this.CacheRepository.SetData("Token:" + Token, Token, ExpiredAt);
        return Token;

        
    }
    
    
    private List<Claim> CreateClaim(Guid Id,string Email)
    {

        var Claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email,Email),
            new Claim(ClaimTypes.NameIdentifier,Id.ToString())

        };


        return Claims;



    }
    
    private SigningCredentials GetSigningCredentials(JwtSetting JWTOption)
    {

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTOption.Key));
        return new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);



    }
    
    private JwtSecurityToken GetJwtToken(JwtSetting JWTOption, List<Claim> claims, SigningCredentials SigningCredentials)
    {

        return new JwtSecurityToken(
            issuer: JWTOption.Issuer,
            audience: JWTOption.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(JWTOption.DurationInMinute),
            signingCredentials: SigningCredentials
        );

    }

    
    private AdminRefreshToken GenerateRefreshToken()
    {

        var RandomNumber = new byte[32];
        var generator = new RNGCryptoServiceProvider();
        generator.GetBytes(RandomNumber);


        return new AdminRefreshToken()
        {
            Token = Convert.ToBase64String(RandomNumber),
            ExpireAt = DateTime.UtcNow.AddDays(30),

        };

    }

    
    
    
    
    
    
   

}