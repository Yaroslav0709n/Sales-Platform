using Microsoft.AspNetCore.SignalR;

namespace SalesPlatform_Application.Hubs
{
    public class ChatHub:Hub 
    {
        public async Task SendMessage(int chatId, string userId, string messageText)
        {
            await Clients.Group(chatId.ToString()).SendAsync("ReceiveMessage", userId, messageText);
        }
    }
}
