using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Models
{
    public class Message
    {
        public Message()
        {
            SentMessages = new List<MessageStatus>();
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<MessageStatus> SentMessages { get; set; }
    }
}
