namespace Common.Exceptions;

public class UnAuthorizationException:Exception
{
    
    
    public UnAuthorizationException():base("You Are Don't have permission to do this action") { 
        
    }
}