using Microsoft.Extensions.Logging;

namespace btcm.Common
{
    public class ApplicationLog
    {

        private readonly ILogger<ApplicationLog> _logger;

        public ApplicationLog(ILogger<ApplicationLog> logger)
        {
            _logger = logger;
        }
        public void MyFunc()
        {
            _logger.Log(LogLevel.Error, "My Message");
        }
    }
}
