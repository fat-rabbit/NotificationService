using Newtonsoft.Json;
using NotificationService.DbInfrastucture;
using NotificationService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotificationService.Services
{
    public interface IMessengerService
    {
        Task<int> SendMessageAsync(ExpectedMessage message);
    }

    public class MessengerService : IMessengerService
    {
        private readonly IMessageRepository _repository;
        public MessengerService(IMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> SendMessageAsync(ExpectedMessage messageDTO)
        {
            var messageId = _repository.SaveMessage(messageDTO);
            var sendMessages = messageDTO.recipients
                .Select(recipient => 
                        SendNotification(new MessageDTO(recipient, messageDTO.body)));
            await Task.WhenAll(sendMessages);
            
            return messageId;
        }

        private async Task SendNotification(MessageDTO message)
        {
            var requestUri = $"fake/notification/";

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"http://localhost:5000");
                var content = new StringContent(JsonConvert.SerializeObject(message));
                var response = await httpClient.PostAsync(requestUri, content);
            }
        }

    }
}
