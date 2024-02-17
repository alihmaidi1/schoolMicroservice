namespace SignalRServer.Hubs.UserConnection;

public interface IUserConnectionManager
{
    public void AddNewConection(Guid userId, string connectionId);

    public void RemoveUserConnection(string connectionId);

    public List<string> GetConnections(Guid userId);
    
    List<string> GetConnections(List<Guid> userIds);
    
}