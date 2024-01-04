using IdentityModel.Client;
using Newtonsoft.Json;
using Repository.Manager.Admin;

namespace Service.Manager.Auth;

public class AuthService:IAuthService
{
    private IAdminRepository AdminRepository;
    private IHttpClientFactory HttpClientFactory;
    public AuthService(IAdminRepository AdminRepository, IHttpClientFactory HttpClientFactory)
    {

        this.HttpClientFactory = HttpClientFactory;
        this.AdminRepository = AdminRepository;

    }

    public async Task<TokenResponse> Login(string email, string Password)
    {


        return null;
    }

    
    
}
