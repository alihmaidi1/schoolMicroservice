using Common.Entity.Interface;

namespace Common.Email;

public interface IMailService :basesuper
{
    
    public bool SendMail(string Email,string subject,string message);
    
}