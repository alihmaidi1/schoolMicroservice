namespace Api;

public static class PasswordRouter
{
    
    
    private const string prefix = Router.Rule + "password";
    public const string ResetPassword = prefix + "/resetpassword";
    public const string CheckCode = prefix + "/checkcode";

    public const string ChangePassword = prefix + "/changepassword";
    
}