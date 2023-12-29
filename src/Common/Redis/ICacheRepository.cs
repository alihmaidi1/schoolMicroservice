namespace Common.Redis;

public interface ICacheRepository
{
    
    public T GetData<T>(string key);

    bool SetData<T>(string key, T Data,DateTimeOffset ExpiredAt);

    object RemoveData(string key);

    public bool IsExists(string key);

    
}