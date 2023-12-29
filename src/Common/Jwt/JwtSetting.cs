namespace Common.Jwt;

public class JwtSetting
{
    
    public string Key {get; set;}
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public double DurationInMinute { get; set; }


}