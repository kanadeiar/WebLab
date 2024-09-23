using Lib.AspNetCore.ServerSentEvents;
using Microsoft.Extensions.Options;

namespace WebApplication1.Sse
{
    public interface INotificationsServerSentEventsService : IServerSentEventsService
    { }

    internal class NotificationsServerSentEventsService : ServerSentEventsService, INotificationsServerSentEventsService
    {
        public NotificationsServerSentEventsService(IOptions<ServerSentEventsServiceOptions<NotificationsServerSentEventsService>> options)
            : base(options.ToBaseServerSentEventsServiceOptions())
        { }
    }
}
