namespace PublisherReader.Service.Interfaces
{
    public interface IPublisherService
    {
        string ListUsers();

        Task SendMessageToAll(string message);
    }
}
