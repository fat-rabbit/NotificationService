using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Models
{
    public class MessageStatus
    {
        [Key, Column(Order = 0)]
        public string RecipientId { get; set; }
        [Key, Column(Order = 0)]
        public int MessageId { get; set; }
        bool IsSent { get; set; } = false;
    }
}
