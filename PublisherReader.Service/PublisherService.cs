using Microsoft.AspNetCore.SignalR;
using PublisherReader.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherReader.Service
{
    public class PublisherService : Hub<IPublisherService>, IPublisherService
    {
        public string ListUsers()
        {
            throw new NotImplementedException();
        }

        public Task SendMessageToAll(string message)
        {
            throw new NotImplementedException();
        }
    }
}
