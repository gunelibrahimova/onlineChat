using Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.SignalR;
using OnlineChat.Models;
using Services;

namespace OnlineChat.SignalR.Hubs
{
    public class ChatHub : Hub
    {

        private MessagesService _messageService;

        public ChatHub(MessagesService messageService)
        {
            _messageService = messageService;
        }
       

        public async Task SendMessage(string userId, string message , string myId)
        {
            Message dbMessage = new()
            {
                Messages = message,
                ReceiverId = userId,
                SenderId = myId,
                
            };
            _messageService.AddMessage(dbMessage);
            await Clients.User(userId).SendAsync("ReceiveMessage" , userId, message, myId);    
        }
      
    }
}
