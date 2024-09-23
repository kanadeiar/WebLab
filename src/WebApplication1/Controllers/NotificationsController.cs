using Lib.AspNetCore.ServerSentEvents;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Sse;

namespace WebApplication1.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly INotificationsServerSentEventsService _serverSentEventsService;

        public NotificationsController(INotificationsServerSentEventsService serverSentEventsService)
        {
            _serverSentEventsService = serverSentEventsService;
        }

        public async void Send()
        {
            //await _serverSentEventsService.SendEventAsync("event: event1\ndata: <div>Content to swap into your HTML page.</div>");
            await _serverSentEventsService.SendEventAsync(new ServerSentEvent
            {
                Id = "1",
                Type = "event1",
                Data = new List<string> { "<div>Content to swap into your HTML page.</div>" },
            });
        }
    }
}
