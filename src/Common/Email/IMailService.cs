namespace Common.Email;

public interface IMailService
{
    
    public bool SendMail(string Email,string subject,string message);
    
}