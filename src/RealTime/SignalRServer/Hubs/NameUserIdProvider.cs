using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs;

public class NameUserIdProvider:IUserIdProvider
{
    public string? GetUserId(HubConnectionContext connection)
    {
        var id=connection.User?.Claims?.Where(x => x.Type == ClaimTypes.NameIdentifier)?.FirstOrDefault()?.Value;
        return id;
    }
}