using Common.Jwt;
using Domain.Enum;

namespace Repository.Manager.Jwt.Factory;

public interface ISchemaFactory
{
    public IJwtRepository CreateJwt(JwtSchema Schema);

}