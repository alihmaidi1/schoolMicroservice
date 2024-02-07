using Api;

namespace Domain.AppMetaData.Manager;

public class RoleRouter
{
    
    public const string prefix = Router.Rule + "role";
    
    public const string Permission = prefix + "/permissions";

    public const string Admin = prefix + "/admins";
    
    
}