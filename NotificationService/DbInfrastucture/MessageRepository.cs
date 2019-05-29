using NotificationService.DTO;
using NotificationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.DbInfrastucture
{

    public interface IMessageRepository
    {
        int SaveMessage(ExpectedMessage messageDTO);
    }

    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int SaveMessage(ExpectedMessage messageDTO)
        {
            var message = new Message()
            {
                Subject = messageDTO.Subject,
                Body = messageDTO.Body
            };

            int messageId = SaveMessage(message);
            SaveMessageStatus(messageDTO.RecipientsList, messageId);

            _context.SaveChanges();
            return messageId;
        }

        private int SaveMessage(Message message)
        {
            _context.Messages.Add(message);
            return message.Id;
        }

        private void SaveMessageStatus(List<string> recipients, int messageId)
        {
            foreach (var recipient in recipients)
            {
                var exists = _context.MessageStatus.Any(x => x.MessageId == messageId && recipient == x.RecipientId);
                if (!exists)
                {
                    _context.MessageStatus.Add(new MessageStatus() { MessageId = messageId, RecipientId = recipient });
                }
            }
        }
    }
}
