using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.DTO
{
    public class MessageDTO
    {
        public MessageDTO(string recipient, string body)
        {
            Recipient = recipient;
            Body = body;
        }

        public string Recipient { get; set; }
        public string Body { get; set; }
    }
}
