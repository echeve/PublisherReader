using Microsoft.AspNetCore.SignalR;
using PublisherReader.Service.Entities;
using PublisherReader.Service.Interfaces;

namespace PublisherReader.Service
{
    public class PublisherService : Hub<IPublisherService>, IPublisherService
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


        public string ListUsers()
        {
            return _readers.ListReaders();
        }

        public async Task SendMessageToAll(string message)
        {
            await Clients.All.SendMessageToAll(message);
        }
    }
}
