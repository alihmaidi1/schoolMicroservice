using System.Text.Json.Serialization;
using Common.Enum;
using Common.Jwt;
using Common.Redis;
using Domain.Enum;
using Infrutructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace Repository.Manager.Jwt.Factory;

public class SchemaFactory:ISchemaFactory
{

    private ICacheRepository cacheRepository;
    private ApplicationDbContext DbContext { get; set; }

    private JwtSetting Setting;
    private IConfiguration configuration;
    public SchemaFactory(IConfiguration configuration,ICacheRepository cacheRepository,ApplicationDbContext DbContext)
    {

        this.configuration = configuration;
        this.cacheRepository = cacheRepository;
        this.DbContext = DbContext;
    }
    
    public IJwtRepository CreateJwt(JwtSchema Schema)
    {
        var Setting=configuration.GetSection(Schema.ToString()).Get<JwtSetting>();
        return new JwtRepository(Setting,this.cacheRepository);
    }
}