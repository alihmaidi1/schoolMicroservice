using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs.Notifications.Student;

public class StudentHub:Hub
{
    
    
    public async Task SendMessage(string content)
    {
        await this.Clients.All.SendAsync("ReceiveMessage", content);
    }
    
}