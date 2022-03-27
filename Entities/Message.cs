using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Messages { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

    }
}
