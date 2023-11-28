namespace PublisherReader.Service.Interfaces
{
    public interface IPublisherHub
    {
        string ListReaders();

        Task SendMessageToAll(string message);
    }
}
