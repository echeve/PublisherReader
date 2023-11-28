using PublisherReader.webApi.Managers.Interface;

namespace PublisherReader.webApi.Managers.Implementation
{
    public class ReaderManager : IReaderManager
    {
        private static IList<string> _reader = new List<string>();

        public void AddReader(string reader)
        {
            if (!_reader.Contains(reader))
            {
                _reader.Add(reader);
            }
        }

        public void RemoveReader(string reader)
        {
            if (_reader.Contains(reader))
            {
                _reader.Remove(reader);
            }
        }

        public string ListConnectedReaders()
        {
            var connectedUsers = string.Empty;
            foreach (var item in _reader)
            {
                connectedUsers += $"reader: {item} {Environment.NewLine}";
            }
            return connectedUsers;
        }
    }
}
