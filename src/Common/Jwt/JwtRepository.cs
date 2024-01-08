using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Common.Redis;
using Microsoft.IdentityModel.Tokens;

namespace Common.Jwt;

public class JwtRepository:IJwtRepository
{
    
    private readonly JwtSetting JwtOption;
    private readonly ICacheRepository CacheRepository;
    
    public JwtRepository(JwtSetting  JwtOption,ICacheRepository cacheRepository)
    {

        this.JwtOption = JwtOption;
        this.CacheRepository = cacheRepository;

    }
    
    public (string refreshToken, string token, int ExpiredAt) GetTokensInfo(Guid Id, string Email,Dictionary<string,string>? Claims=null)
    {
        string Token = GetToken(Id,Email,Claims);
        string RefreshToken = GenerateRefreshToken();
        return (RefreshToken, Token,(int )JwtOption.DurationInMinute * 60);
    }

    
    public string GetToken(Guid Id, string Email, Dictionary<string,string>? Claims)
    {
        
        var claims = CreateClaim(Id,Email,Claims);
        var signingCredentials = GetSigningCredentials(JwtOption);
        var JwtToken = GetJwtToken(JwtOption, claims, signingCredentials);
        var Token = new JwtSecurityTokenHandler().WriteToken(JwtToken);
        var ExpiredAt = DateTimeOffset.Now.AddMinutes(JwtOption.DurationInMinute);
        CacheRepository.SetData("Token:" + Token, Token, ExpiredAt);
        return Token;

    }
    
    
    
    private List<Claim> CreateClaim(Guid Id,string Email,Dictionary<string,string> ListClaims=null)
    {


        var Claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email,Email),
            new Claim(ClaimTypes.NameIdentifier,Id.ToString())

        };

        if (ListClaims is not null)
        {
       
            foreach (var claim in ListClaims)
            {
            
                Claims.Add(new Claim(claim.Key,claim.Value));
            
            }

            
        }
        
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

    
    private string GenerateRefreshToken()
    {

        var RandomNumber = new byte[32];
        var generator = new RNGCryptoServiceProvider();
        generator.GetBytes(RandomNumber);

        return Convert.ToBase64String(RandomNumber);

    }

}