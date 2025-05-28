using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace apiCatalogo.Filters
{
    /// <summary>
    /// Filtro de excessão
    /// </summary>
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        /// <summary>
        /// Contrutor da classe
        /// </summary>
        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Executado quando uma exceção não tratada é lançada
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Ocorreu uma excessão não tratada: Status Code 500");

            context.Result = new ObjectResult("Ocorreu um problema ao tratar a sua solicitação")
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }
    }
}
