using Microsoft.AspNetCore.SignalR;
using PublisherReader.webApi.Managers.Interface;

namespace PublisherReader.webApi.Hubs
{
    public class NotificationsHub : Hub
    {
        private readonly IReaderManager _readerManager;
        private readonly ILogger<NotificationsHub> _logger;
        public NotificationsHub(IReaderManager readerManager, ILogger<NotificationsHub> logger)
        {
            _readerManager = readerManager ?? throw new ArgumentNullException(nameof(readerManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public override Task OnConnectedAsync()
        {
            _logger.LogInformation($"Connected user: {Context.ConnectionId}");
            _readerManager.AddReader(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _logger.LogInformation($"Disconnected user: {Context.ConnectionId}");
            _readerManager.RemoveReader(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

    }
}
