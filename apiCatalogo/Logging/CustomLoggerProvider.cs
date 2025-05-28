using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace apiCatalogo.Logging
{
    /// <summary>
    /// Provedor de log
    /// </summary>
    public class CustomLoggerProvider : ILoggerProvider
    {
        private readonly CustomLoggerProviderConfig _loggerConfig;

        private readonly ConcurrentDictionary<string, CustomLogger> _loggers = new ConcurrentDictionary<string, CustomLogger> ();

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="config"></param>
        public CustomLoggerProvider(CustomLoggerProviderConfig config)
        {
            _loggerConfig = config;
        }

        /// <summary>
        /// Cria o log
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new CustomLogger(name, _loggerConfig));
        }

        /// <summary>
        /// Liberar recursos
        /// </summary>
        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
