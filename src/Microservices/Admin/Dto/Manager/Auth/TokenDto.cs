namespace Dto.Manager.Auth;

public class TokenDto
{
    public string Token { get; set; }

    public string ?RefreshToken { get; set; }

    public int ExpiredAt { get; set; }
    public static TokenDto ToTokenDto(string Token,int ExpiredAt,string RefreshToken=null)
    {

        return new TokenDto
        {
            Token=Token,
            ExpiredAt=ExpiredAt,
            RefreshToken=RefreshToken

        };

    }

}