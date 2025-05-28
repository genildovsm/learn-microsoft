namespace apiCatalogo.Logging
{
    /// <summary>
    /// Configuração do provedor de logs
    /// </summary>
    public class CustomLoggerProviderConfig
    {
        /// <summary>
        /// Define o nível mínimo de log a ser registrado
        /// </summary>
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        /// <summary>
        /// Define o ID do evento de log
        /// </summary>
        public int EventId { get; set; } = 0;
    }
}
