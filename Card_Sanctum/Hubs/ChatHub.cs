using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            if (String.IsNullOrEmpty(user) || string.IsNullOrEmpty(message))
            {
                return;
            }

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}