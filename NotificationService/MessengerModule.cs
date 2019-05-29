using Nancy;
using Nancy.ModelBinding;
using NotificationService.DTO;
using NotificationService.Services;

namespace NotificationService
{
    public class MessengerModule : NancyModule
    {
        private IMessengerService _service;
        public MessengerModule(IMessengerService service) : base("/message")
        {
            _service = service;
            Post("/send/", async (parameters, _) =>
            {
                var message = this.Bind<ExpectedMessage>();
                var response = await _service.SendMessageAsync(message);

                return $"response: {response}";
            });
        }
    }

}
