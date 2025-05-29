
using System.Runtime.CompilerServices;

namespace apiCatalogo.Logging
{
    /// <summary>
    /// Log customizado
    /// </summary>
    public class CustomLogger : ILogger
    {
        private readonly string _loggerName;

        private readonly CustomLoggerProviderConfig _loggerConfig;

        /// <summary>
        /// Contrutor da classe
        /// </summary>
        /// <param name="name">Nome da classe ou componente que fará uso do log</param>
        /// <param name="config">Configuração específica para esse log</param>
        public CustomLogger(string name, CustomLoggerProviderConfig config)
        {
            _loggerName = name;
            _loggerConfig = config;
        }

        /// <summary>
        /// Permite criar um escopo para as mensagens de logs (não será utilizado)
        /// </summary>
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        /// <summary>
        /// Verifica se o nível de log está habilitado com base na configuração
        /// </summary>        
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _loggerConfig.LogLevel;
        }

        /// <summary>
        /// Registra a mensagem de log
        /// </summary>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string mensagem = $"{DateTime.Now} {logLevel}: [ {eventId.Id} ] - {formatter(state, exception)}";

            EscreverNoArquivo(mensagem);
        }

        private async void EscreverNoArquivo(string texto)
        {
            
            string diretorioLog = Environment.CurrentDirectory + $"/Logs";
            string arquivoLog = $"{diretorioLog}/{DateTime.Now.Year}{DateTime.Now.Month.ToString().PadLeft(2, '0')}{DateTime.Now.Day.ToString().PadLeft(2, '0')}.log";

            using StreamWriter streamWriter = new (arquivoLog, true);

            try
            {
                await streamWriter.WriteLineAsync(texto);
                streamWriter.Close();
            }
            catch
            {
                throw;
            }
        }
    }
}
