using IdentityModel.Client;

namespace Service.Manager.Auth;

public interface IAuthService
{

    public Task<TokenResponse> Login(string email,string Password);


}