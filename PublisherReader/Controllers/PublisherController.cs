using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PublisherReader.webApi.Hubs;
using PublisherReader.webApi.Managers.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PublisherReader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IHubContext<NotificationsHub>  _hub;
        private readonly IReaderManager _readerManager;

        public PublisherController(IHubContext<NotificationsHub> hub,
            IReaderManager readerManager) 
        { 
            _hub = hub ?? throw new ArgumentNullException(nameof(hub));
            _readerManager = readerManager ?? throw new ArgumentNullException(nameof(_readerManager));
        }

        // GET: api/<PublisherController>
        [HttpGet]
        public string Get()
        {
            var readers = _readerManager.ListConnectedReaders();
            return readers;
        }

        // POST api/<PublisherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _hub.Clients.All.SendAsync("SendMessageToAll", value);
        }
    }
}
