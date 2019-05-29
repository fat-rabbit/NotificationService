using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.DTO
{
    public class ExpectedMessage
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> Recipients { get; set; }
        public bool IsSent { get; set; } = true;
    }
}
