using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices
{
    public class HostServiceTest : BackgroundService
    {
        private readonly ILogger<HostServiceTest> _logger;
        public HostServiceTest(ILogger<HostServiceTest> logger)
        {
            _logger = logger;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Host service test Task partito");
            stoppingToken.Register(() => _logger.LogInformation("Host service test Task stopping"));
            //  throw new NotImplementedException();
            return;
        }
    }
}
