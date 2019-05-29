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
        public string Recipients { get; set; }
        [NotMapped]
        public List<string> RecipientsList
        {
            get
            {
                return Recipients.Split(',').ToList();
            }
            set
            {
                Recipients = (value != null) ? string.Join(',', value) : "";
            }
        }
        public bool IsSent { get; set; } = true;
    }
}
