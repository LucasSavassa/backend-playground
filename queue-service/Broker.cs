using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace QueueService
{
    internal class Broker : BackgroundService
    {
        private readonly ILogger<Broker> _logger;
        private readonly Channel<Message> _queue;

        public Broker(ILogger<Broker> logger, int capacity)
        {
            _logger = logger;
            _queue = Channel.CreateBounded<Message>(capacity);
        }

        public Broker(ILogger<Broker> logger)
        {
            _logger = logger;
            _queue = Channel.CreateUnbounded<Message>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
