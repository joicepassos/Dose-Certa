using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatApp.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task Connect(string user)
    {
        await Clients.All.SendAsync("UserConnected", user);
    }

    public async Task Disconnect(string user)
    {
        await Clients.All.SendAsync("UserDisconnected", user);
    }
}
