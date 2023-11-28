namespace PublisherReader.Service.Entities
{
    public class Reader
    {
        private IList<string> _reader;

        public Reader() 
        {
            _reader = new List<string>();   
        }

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

        public string ListReaders()
        {
            var connectedUsers = string.Empty;
            foreach (var item in _reader)
            {
                connectedUsers += $"reader: {item} {Environment.NewLine}";
            }
            return connectedUsers;
        }

        public void DisconectReaders()
        {
            _reader = new List<string>();
        }
    }
}
