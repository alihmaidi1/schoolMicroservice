namespace Api;

public class AuthAdminRouter
{
    
    private const string prefix = Router.Rule + "manager";
    
    public const string Login = prefix + "/login";

    public const string Logout = prefix + "/logout";

    public const string RefreshToken = prefix + "/refreshtoken";
}