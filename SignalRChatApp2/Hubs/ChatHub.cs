using Microsoft.AspNetCore.SignalR;
using SignalRChatApp2.Models;
using System.Threading.Tasks;

namespace SignalRChatApp2.Hubs
{
    public class ChatHub :Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.Others.SendAsync("receiveMessage", message);
        } 
    }
}
