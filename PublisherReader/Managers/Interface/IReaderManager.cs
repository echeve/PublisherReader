namespace PublisherReader.webApi.Managers.Interface
{
    public interface IReaderManager
    {
        void AddReader(string reader);

        void RemoveReader(string reader);

        string ListConnectedReaders();

    }
}
