using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MessagesService
    {
        private readonly ChatDbContext _context;

        public MessagesService(ChatDbContext context)
        {
            _context = context;
        }

        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public List<Message> GetMyMessages(string myId, string userId)
        {
           return  _context.Messages.Where(x => (x.ReceiverId == myId && x.SenderId == userId) || (x.ReceiverId == userId && x.SenderId == myId)).ToList();
        }
    }
}
