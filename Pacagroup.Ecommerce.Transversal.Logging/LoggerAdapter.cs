using Microsoft.Extensions.Logging;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Transversal.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {

        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<T>();
        }

        public void LogginError(string Message, params object[] args)
        {
            _logger.LogError(Message, args);
        }

        public void LogginInformation(string Message, params object[] args)
        {

            _logger.LogInformation(Message, args);

        }

        public void LogginWarning(string Message, params object[] args)
        {
            _logger.LogWarning(Message, args);
        }
    }
}
