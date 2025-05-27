using Microsoft.AspNetCore.Mvc.Filters;

namespace apiCatalogo.Filters
{
    /// <summary>
    /// Filtro para implementação de logs
    /// </summary>
    public class ApiLoggingFilter : IActionFilter
    {
        /// <summary>
        /// Instância de ILogger
        /// </summary>
        private readonly ILogger<ApiLoggingFilter> _logger;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="logger"></param>
        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Método executado após a action
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("### Executando -> OnActionExecuted");
            _logger.LogInformation("-------------");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString}");
            _logger.LogInformation("-------------");
            _logger.LogInformation($"StatusCode : {context.HttpContext.Response.StatusCode}");
        }

        /// <summary>
        /// Método executado antes da action
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("### Executando -> OnActionExecuting");
            _logger.LogInformation("-------------");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString}");
            _logger.LogInformation("-------------");
            _logger.LogInformation($"ModelState : {context.ModelState.IsValid}");
        }
    }
}
