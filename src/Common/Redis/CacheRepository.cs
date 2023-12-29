using System.Text.Json;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Common.Redis;

public class CacheRepository:ICacheRepository
{
    
    IDatabase RedisDB;


    public CacheRepository(IConfiguration configration)
    {
        var RedisConnection = configration.GetRequiredSection("RedisConnection").Value;
        var redis = ConnectionMultiplexer.Connect(RedisConnection);
        RedisDB = redis.GetDatabase();

    }
    public T GetData<T>(string key)
    {
        var value = RedisDB.StringGet(key);
        if (!string.IsNullOrEmpty(value))
        {


            return JsonSerializer.Deserialize<T>(value);
        }

        return default;
    }
    
    
    

    public bool SetData<T>(string key, T Data, DateTimeOffset ExpiredAt)
    {
        
        var ExpiredTime = ExpiredAt.Subtract(DateTime.Now);
        var IsSet = RedisDB.StringSet(key, JsonSerializer.Serialize(Data), ExpiredTime);
        return IsSet;
    }

    public object RemoveData(string key)
    {
        var exists = RedisDB.KeyExists(key);
        if (exists)
        {

            return RedisDB.KeyDelete(key);
        }

        return false;

    }

    public bool IsExists(string key)
    {
        var value = RedisDB.StringGet(key);
        return !string.IsNullOrEmpty(value);

    }
}