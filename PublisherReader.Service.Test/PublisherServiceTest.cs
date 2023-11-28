using Microsoft.AspNetCore.SignalR;
using Moq;

namespace PublisherReader.Service.Test
{
    [TestFixture]
    public class PublisherServiceTest
    {
        PublisherService _sut;
        Mock<HubCallerContext> _hubContextMock;

        [SetUp]
        public void Setup()
        {
            _sut = new PublisherService();
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
            Assert.IsNotEmpty(_sut.ListUsers());
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
            Assert.IsEmpty(_sut.ListUsers());
        }

        [Test]
        public async Task List_connected_users_Should_List_all_readers_connected()
        {
            //Arrange
            _hubContextMock.SetupGet(hc => hc.ConnectionId).Returns("Pablo");
            await _sut.OnConnectedAsync();

            //Act
            var result = _sut.ListUsers();

            //Assert
            Assert.IsNotEmpty(result);
            Assert.That(result.Contains("reader: Pablo"));
        }
    }
}
