using RabbitMQ.Client;
using System.Text;

namespace Domain.Publisher
{
    public class Publisher : IPublisher
    {
        private bool _disposed;
        private IConnection? _connection;
        private IChannel? _channel;
        private readonly string _queue;
        private readonly string _name;

        public string Name => _name;

        public Publisher(string name, string queue)
        {
            _name = name;
            _queue = queue;

            InitializeChannel();
        }

        private void InitializeChannel()
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnectionAsync().Result;
            _channel = _connection.CreateChannelAsync().Result;
        }

        public async Task Publish(string message)
        {
            if (!CanPublish())
            {
                return;
            }

            await _channel!.QueueDeclareAsync(
                queue: _queue,
                exclusive: false);

            byte[] body = Encoding.UTF8.GetBytes(message);

            await _channel!.BasicPublishAsync(
                exchange: string.Empty,
                routingKey: _queue,
                body: body);
        }

        private bool CanPublish()
        {
            return _channel != null && _connection != null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _channel?.Dispose();
                    _connection?.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
