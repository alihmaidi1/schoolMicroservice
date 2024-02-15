using Common.Entity.Interface;
using Common.Enum;
using Common.Jwt;
using Domain.Enum;

namespace Repository.Manager.Jwt.Factory;

public interface ISchemaFactory :basesuper
{
    public IJwtRepository CreateJwt(JwtSchema Schema);

}