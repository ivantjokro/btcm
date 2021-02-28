using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
