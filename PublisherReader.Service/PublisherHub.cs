using Microsoft.AspNetCore.SignalR;
using PublisherReader.Service.Entities;
using PublisherReader.Service.Interfaces;

namespace PublisherReader.Service
{
    public class PublisherHub : Hub, IPublisherHub
    {
        private static Readers _readers = new Readers();

        public override Task OnConnectedAsync()
        {
            _readers.AddReader(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _readers.RemoveReader(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }


        public string ListReaders()
        {
            return _readers.ListReaders();
        }

        public async Task SendMessageToAll(string message)
        {
            await Clients.All.SendAsync("SendMessageToAll", message);
        }
    }
}
