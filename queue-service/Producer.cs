using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueService
{
    internal class Producer : BackgroundService
    {
        private readonly ILogger<Producer> _logger;

        public Producer(ILogger<Producer> logger)
        {
            _logger = logger;
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
