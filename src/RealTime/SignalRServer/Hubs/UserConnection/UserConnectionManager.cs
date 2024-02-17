namespace SignalRServer.Hubs.UserConnection;

public class UserConnectionManager:IUserConnectionManager
{
    private static Dictionary<Guid, List<string>> userConnectionMap = new();
    private static string Locker = string.Empty;


    public void AddNewConection(Guid userId, string connectionId)
    {

        lock (Locker)
        {
            if (userConnectionMap.SelectMany(x => x.Value).Any(x=>x.Equals(connectionId)))
            {
                return;
            }
            if (!userConnectionMap.ContainsKey(userId))
            {
                userConnectionMap[userId] = new List<string>();
            }
            userConnectionMap[userId].Add(connectionId);
            
        }
        
    }



    public void RemoveUserConnection(string connectionId)
    {

        lock (Locker)
        {
            foreach (var userId in userConnectionMap.Keys)
            {
                    if (userConnectionMap[userId].Contains(connectionId))
                    {
                        userConnectionMap[userId].Remove(connectionId);
                        break;
                    }
                
            }

        }
        
        
    }


    public List<string> GetConnections(Guid userId)
    {
        var conn = new List<string>();
        
        lock (Locker)
        {
            if (userConnectionMap.ContainsKey(userId))
            {
                conn = userConnectionMap[userId];
            }
            else
            {
                return new List<string>();
            }
            
        }
        
        return conn;

    }

    
    public List<string> GetConnections(List<Guid> userIds)
    {
        var conn = new List<string>();

        foreach (var userId in userIds)
        {
            conn.AddRange(GetConnections(userId));
        }
        return conn;
    }

    
    
}