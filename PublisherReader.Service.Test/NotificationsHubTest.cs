using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Moq;
using PublisherReader.webApi.Hubs;
using PublisherReader.webApi.Managers.Interface;

namespace PublisherReader.Service.Test
{
    [TestFixture]
    public class NotificationsHubTest
    {
        NotificationsHub _sut;
        Mock<HubCallerContext> _hubContextMock;
        Mock<IReaderManager> _readerManagerMock;
        Mock<ILogger<NotificationsHub>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _readerManagerMock = new Mock<IReaderManager>();
            _loggerMock = new Mock<ILogger<NotificationsHub>>();
            _sut = new NotificationsHub(_readerManagerMock.Object, _loggerMock.Object);
            _hubContextMock = new Mock<HubCallerContext>();
            _sut.Context = _hubContextMock.Object;
        }

        [Test]
        public async Task Connect_New_Reader_Should_Add_Reader()
        {
            //Arrange
            _hubContextMock.SetupGet(hc => hc.ConnectionId).Returns("Pablo");

            //Act
            await _sut.OnConnectedAsync();

            //Assert
            _readerManagerMock.Verify(reader => reader.AddReader("Pablo"), Times.Once);
        }

        [Test]
        public async Task Disconect_user_it_should_return_empty_list()
        {
            //Arrange
            _hubContextMock.SetupGet(hc => hc.ConnectionId).Returns("Pablo");
            await _sut.OnConnectedAsync();

            //Act
            await _sut.OnDisconnectedAsync(null);

            //Assert
            _readerManagerMock.Verify(reader => reader.RemoveReader("Pablo"), Times.Once);
        }
    }
}
